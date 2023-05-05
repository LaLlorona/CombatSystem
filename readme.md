# README

# 목차

# 게임플레이 데모 영상

[Currently developing game](https://www.youtube.com/watch?v=g8cE42-RxTE)

# 게임 소개

![1.PNG](README%209d246cdc2ace4ec291c82dc2fff6d904/1.png)

세 캐릭터를 교체하며 싸워나가는 3d 액션 게임입니다. 

캐릭터 교체시 특정 조건을 만족할 경우 고유 스킬이 사용되게 함으로써 플레이어가 여러 캐릭터를 사용하도록 유도하는 전투방식을 구현하였습니다. 

# 구현 내용 및 구현 방식

## 공격 및 스킬 사용시 플레이어의 움직임 제어

플레이어가 스킬을 사용하거나 공격을 하는 동안 움직임과 방향은 다음과 같은 규칙으로 구현하였습니다.

1. 캐릭터가 공격이나 스킬을 사용할 때의 **캐릭터 움직임은 애니메이션의 root motion 에 의해 캐릭터가 제어**되도록 할 것 
2. 캐릭터가 공격이나 스킬을 사용할 때 캐릭터의 회전 방향은 
    1. **실제 공격판정이 들어가기 전**까지는 **자유롭게 회전**할 수 있게 한다.
    2. **공격 판정이 들어간 이후**부터 **공격 애니메이션이 끝날 때 까지**는 **캐릭터의 방향을 고정**한다. 

 

캐릭터가 플레이어의 키보드 인풋값을 기반으로 움직일지, 혹은 애니메이션의 root motion을 기반으로 움직일지를 판별하기 위해 `AnimatorManager.cs` 내부에 `rootMotionEnabled` 변수를 사용하였습니다. `PlayTargetAnimation` 메소드를 통해 스킬 사용시 root motion 을 활성화 하였습니다. 

**AnimatorManager.cs**

```csharp
public void PlayTargetAnimation(string targetAnim, bool isRootMotion, float crossFadeTime, bool setCanBeInterrupted = true, bool setCanRotate = true)
        {
            if (!canBeInterrupted)
            {
                return;
            }   
            anim.applyRootMotion = isRootMotion;
            
            
            anim.SetBool(isRootMotionHash, isRootMotion);
            anim.SetBool(canBeInterruptedHash, setCanBeInterrupted);
            anim.SetBool(canRotateHash, setCanRotate);
            anim.CrossFade(targetAnim, crossFadeTime);

            rootMotionEnabled = isRootMotion;

        }
```

만약 `rootMotionEnabled` 가 true 일 경우 플레이어의 input 에 따라 캐릭터를 움직이는 `MoveWalk` 메소드를 return 하고, `OnAnimatorMove` 메소드를 통해 애니메이션의 root motion에 따라 캐릭터가 움직이도록 구현하였습니다.  

**CharacterLocomotion.cs**

```csharp
//
private void MoveWalk()
        {
            if (mainCharacterManager.currentCharacterAnimatedController.rootMotionEnabled && !mainCharacterManager.currentCharacterAnimatedController.canRotate)
            {//roll, skills... etc
                
                return;
            }
//이하 생략
					
}
```

**AnimatedController.cs**

```csharp
private void OnAnimatorMove()
        {
            if (!rootMotionEnabled)
            {
                return;
            }

            float delta = Time.deltaTime;
            characterManager.rigidbody.drag = 0;
            Vector3 deltaPosition = anim.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            characterManager.rigidbody.velocity = velocity;
        }
```

캐릭터의 방향이 고정되는 시점은 공격 애니메이션이 플레이 된 직후가 아닌 공격 판정이 들어가는 때입니다. 이를 구현하기 위해 Animation Event 에서 공격 판정이 활성화 되는 시점에 실행되는 이벤트인 `onAttackOpen`, `onSkillOpen`, `onQteOpen` 에 캐릭터의 회전을 비활성화하는 `DisableRotate` 를 등록하는 방식으로 구현하였습니다.  

**AnimatedController.cs**

```csharp
private void OnEnable()
        {

            characterAnimationEventHandler.onAttackOpen += DisableRotate;
            characterAnimationEventHandler.onSkillOpen += DisableRotate;
            characterAnimationEventHandler.onQteOpen += DisableRotate;
        }

        private void OnDisable()
        {

            characterAnimationEventHandler.onAttackOpen -= DisableRotate;
            characterAnimationEventHandler.onSkillOpen -= DisableRotate;
            characterAnimationEventHandler.onQteOpen -= DisableRotate;
        }

public void DisableRotate()
        {
            anim.SetBool(canRotateHash, false);
        }
```

![Untitled](README%209d246cdc2ace4ec291c82dc2fff6d904/Untitled.png)

공격 애니메이션이 끝난 경우 `rootMotionEnabled` 의 값을 `false` 로 바꿔야 하기 때문에, animator 의 `StateMachineBehavior` 에서 `rootMotionEnabled` 의 값을 `false` 초기화하였습니다. 

![Untitled](README%209d246cdc2ace4ec291c82dc2fff6d904/Untitled%201.png)

## 스킬 시스템

![Untitled](README%209d246cdc2ace4ec291c82dc2fff6d904/Untitled%202.png)

회피를 하여 수급한 sp 를 통해 스킬을 사용할 수 있습니다.

스킬을 사용할 경우 현재 활성화 된 캐릭터가 장착하고 있는 charaterWeapon의 weaponArtName 에 해당하는 애니메이션이 실행됩니다. 

**CharacterSkillHandler.cs**

```csharp

public void UseWeaponArt()
    {
        if (CanUseWeaponArt())
        {
            MainCharacterManager.Instance.currentIndividualCharacterManager.characterCreature.ChangeMpValue(-MainCharacterManager.Instance.currentIndividualCharacterManager.characterWeapon.weaponMpConsume); 
                    
            Debug.Log($"current character name is {MainCharacterManager.Instance.currentIndividualCharacterManager.characterItemInfo.itemName}");
            MainCharacterManager.Instance.currentCharacterAnimatedController.anim.SetBool(isAttackingHash, true);
            MainCharacterManager.Instance.currentCharacterAnimatedController.PlayTargetAnimation(MainCharacterManager.Instance.currentIndividualCharacterManager.characterWeapon.weaponArtName,
                true, 0.2f);
        }
            
    }
```

![Untitled](README%209d246cdc2ace4ec291c82dc2fff6d904/Untitled.png)

스킬 애니메이션이 실행되는 중 스킬이 사용되어야 하는 타이밍에 Animation Event 를 등록하였습니다. 이 이벤트는 `CharacterAnimationEventHandler.cs` 에서 이벤트로써 관리됩니다. 

**CharacterAnimationEventHandler.cs**

```csharp
//CharacterAnimationEventHandler.cs
public delegate void CharacterAnimationEvent();
public CharacterAnimationEvent onSkillOpen;

public void OnSkillOpen()
    {
        onSkillOpen?.Invoke();
    }
```

각 코드에서 스킬이 사용될 경우 실행할 method 를 onSkillOpen 이벤트에 등록합니다. 

**CharacterCombatHandler.cs**

```csharp
//CharacterCombatHandler.cs
mainCharacterManager.currentCharacterAnimationEventHandler.onSkillOpen += ActivateSkill;
```

## 캐릭터 교체 시스템

![Untitled](README%209d246cdc2ace4ec291c82dc2fff6d904/Untitled%203.png)

교체하려는 캐릭터의 교체쿨타임이 끝났을 경우 캐릭터를 교체할 수 있습니다.

현재 장착된 캐릭터들의 정보를 관리하는 `MaincharacterManager.cs` 에서 각 캐릭터가 교체 할 수 있는 상황인지 여부를 판단합니다. 교체시 `EnableCharacterWithIndex(int index)` 메소드를 호출합니다.

**MaincharacterManager.cs**

```csharp
public void EnableCharacterWithIndex(int index)
        {
            if (currentCharacterIndex == index || !individualCharacterManagers[index].canChangeCharacter)
            {
                return;
            }
            HideAllCharacterGameobjects();
            currentCharacterIndex = index;
            currentIndividualCharacterManager = individualCharacterManagers[index];

            currentIndividualCharacterManager.individualCharacterGameobject.SetActive(true);

            currentCharacterAnimatedController = currentIndividualCharacterManager.animatedController;
            currentCharacterAnimationEventHandler = currentIndividualCharacterManager.characterAnimationEventHandler;

            currentWeaponType = currentIndividualCharacterManager.characterWeapon.weaponType;

            characterCombatHandler.AssignAttackInput();
            
            currentIndividualCharacterManager.BeginCharacterChangeTimer();

            currentIndividualCharacterManager.characterCreature.SetCharacterActive();

            weaponSlotManager.LoadWeaponOnHand(currentIndividualCharacterManager.characterWeapon);

            uiManager.SetHPUI();
            uiManager.SetMPUI();

            characterCombatHandler.UpdateDamageColliderInformation(currentIndividualCharacterManager);

            characterCombatHandler.PlayQTEAnimationOnChange(index);
            
            characterCombatHandler.UpdateAttackAdditionalEffectChecker();
            
            onCharacterChange?.Invoke(index);
        }
```

캐릭터 교체시 일어나야 하는 이벤트가 많기 때문에 `EnableCharacterWithIndex(int index)` 에서 다른 메소드를 직접 호출하는 것은 유지보수가 어렵다는 것을 알았습니다. 그렇기 때문에 다시 구현한다면 이 방식이 아니라, `MaincharacterManager.cs` 내에 이벤트를 만들어 캐릭터 교체가 일어날 때 이 이벤트에 메소드를 등록하는 방식으로 구현할 예정입니다. 

## 캐릭터 교체시 조건에 따른 QTE 시스템

![Untitled](README%209d246cdc2ace4ec291c82dc2fff6d904/Untitled%204.png)

캐릭터 교체시 특정 조건을 만족하면 교체할 경우 QTE 스킬을 사용하도록 설계하였습니다. 

각 캐릭터의 scriptable object 에서 교체시 QTE 스킬을 사용하기 위한 조건에 해당하는 `qteConditions` 가 List 형태로 존재합니다. 캐릭터가 적에게 상태이상을 부여할 경우,  `UpdateAttackAdditionalEffectChecker()` 가 호출되며, `qteCondition`을 만족할 경우, 캐릭터가 교체할 때 QTE 스킬을 사용할 수 있는 여부를 저장하는 `characterQteCondition` 의 캐릭터 index 에 해당하는 값을 `true` 로 설정합니다. 리스트간 비교를 위해 `System.Linq;` 라이브러리의 `Intersect` 메소드를 사용하였습니다. 

**CharacterCombatHandler.cs**

```csharp
public void UpdateAttackAdditionalEffectChecker()
        {
            
            
            for (var i = 0; i < MainCharacterManager.Instance.individualCharacterManagers.Length; i++)
            {
                CharacterItem currentCharacterItem = MainCharacterManager.Instance.individualCharacterManagers[i].characterItemInfo;
                characterQteCondition[i] = MainCharacterManager.Instance.individualCharacterManagers[i].canChangeCharacter &&
                    currentCharacterItem.qteConditions.Intersect(attackAdditionalEffectChecker).Any();
                UIManager.Instance.ToggleQteIndicator(i, (characterQteCondition[i]));
                
            }
        }
```

## 락온 시스템

![Untitled](README%209d246cdc2ace4ec291c82dc2fff6d904/Untitled%205.png)

락온 가능 거리 내에서 현재 유저가 바라보고 있는 지점에서 50도 이내에 있는 가장 가까운 각거리의 적을 락온합니다.

공격을 할 경우, 캐릭터는 락온된 대상 방향으로 자동으로 회전합니다. 

  

**CameraManager.cs**

```csharp
//CameraManager.cs
public void FindAvailableLockOnTarget()
        {
            avaiableTargets.Clear();
            nearestLockOnTarget = null;
            float shortestDistance = Mathf.Infinity;

            Collider[] colliders = Physics.OverlapSphere(characterLocomotion.transform.position, lockOnRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                CharacterManager character = colliders[i].GetComponent<CharacterManager>();
                
                if (character != null)
                {
                    Vector3 lockTargetDirection = character.transform.position - characterLocomotion.transform.position;

                    float viewableAngle = Vector3.Angle(lockTargetDirection, mainCamera.transform.forward);

                    if (characterLocomotion.transform.root != character.transform.root && viewableAngle > -50 && viewableAngle < 50)
                    {
                        avaiableTargets.Add(character);
                    }
                }
            }

            for (int i = 0; i < avaiableTargets.Count; i++)
            {
                float distanceFromTarget = Vector3.SqrMagnitude(avaiableTargets[i].transform.position - characterLocomotion.transform.position);

                if (distanceFromTarget < shortestDistance)
                {
                    shortestDistance = distanceFromTarget;
                    nearestLockOnTarget = avaiableTargets[i].lockOnTransform;
                }
            }
        }
```

`CameraManager.cs` 의 `Update` 메소드에서 `FindAvailableLockOnTarget` 함수를 매 프레임 호출합니다. 

이 메소드에서는 `Physics.OverlapSphere` 메소드를 통해 캐릭터로부터 특정 거리 내부의 적들의 거리 정보를 저장합니다. 그 후 `Vector3.Angle` 메소드를 통해 `mainCamera.transform.forward` 로부터 50도 내부에 있는 적들 중 가장 가까운 각거리의 적을 타겟으로 설정합니다. 

**CharacterLocomotion.cs**

```csharp
//CharacterLocomotion.cs
//MoveWalk() method
else if (mainCharacterManager.currentCharacterAnimatedController.isAttacking)
            {//player attack
                GameObject targetEnemy = MainCharacterManager.Instance.targetEnemy;
                if (MainCharacterManager.Instance.targetEnemy != null)
                {
                    Vector3 enemyPos = targetEnemy.transform.position;
                    Vector3 playerToEnemy = enemyPos - gameObject.transform.position;
                    targetAngle = Quaternion.LookRotation(playerToEnemy).eulerAngles.y;
                    return;
                }
                
            }
```

현재 캐릭터가 공격중인 경우, `FindAvailableLockOnTarget()`에서 적용한 `targetEnemy` 가 존재할 경우, `Quaternion.LookRotation` 메소드를 통해 캐릭터를 `targetEnemy` 방향으로 회전합니다.