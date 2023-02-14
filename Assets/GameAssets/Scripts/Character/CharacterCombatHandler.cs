using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KMK.AnimationNameDefine;

namespace KMK
{
    public class CharacterCombatHandler : MonoBehaviour
    {
        
        CharacterInventory characterInventory;
        MainCharacterManager mainCharacterManager;
        public InputReader input;
        


        public MeleeDamageCollider swordCollider;
        public MeleeDamageCollider fistCollider;

        
        

        public bool isAttackButtonAlreadyPressed = false;


        public void UpdateDamageColliderInformation(IndividualCharacterManager individualCharacterManager)
        {
            float weaponDamage = individualCharacterManager.characterWeapon.baseDamage + individualCharacterManager.characterCreature.strength;
            swordCollider.DisableDamageCollider();
            fistCollider.DisableDamageCollider();
            if (individualCharacterManager.characterWeapon.weaponType == WeaponType.Sword)
            {
                swordCollider.damage = weaponDamage;
                
            }

            else if (individualCharacterManager.characterWeapon.weaponType == WeaponType.Knuckle)
            {
                fistCollider.damage = weaponDamage;
            }

            else if (individualCharacterManager.characterWeapon.weaponType == WeaponType.Wand)
            {

            }
        }

        public void PlayQTEAnimationOnChange()
        {
            if (true)
            { //condition check for each character. Does it satisfies QTE conditions?

                mainCharacterManager.currentCharacterAnimatedController.anim.SetBool(isAttackingHash, true);
                mainCharacterManager.currentCharacterAnimatedController.PlayTargetAnimation(mainCharacterManager.currentIndividualCharacterManager.characterItemInfo.qteArtName,
                   true, 0.2f);
            }
        }

        private void Awake()
        {

            characterInventory = GetComponent<CharacterInventory>();
            mainCharacterManager = GetComponent<MainCharacterManager>();

        }

        private void OnEnable()
        {
            

            input.onAttackButtonInput += PressWeakAttackButton;
            input.onRollInput += Roll;
            input.onWeaponArtInput += UseWeaponArt;

        }

        private void OnDisable()
        {
        
            input.onAttackButtonInput -= PressWeakAttackButton;
            input.onRollInput -= Roll;
            input.onWeaponArtInput -= UseWeaponArt;

        }

        public void HandleAttackOpen()
        {
           
            WeaponType currentWeaponType = mainCharacterManager.currentIndividualCharacterManager.characterWeapon.weaponType;
            if (currentWeaponType == WeaponType.Knuckle)
            {
                fistCollider.EnableDamageCollider();
            }

            else if (currentWeaponType == WeaponType.Sword)
            {
                swordCollider.EnableDamageCollider();
            }

            else
            {
                Debug.Log("projectile weapon");
                WandItem wandItem = (WandItem)mainCharacterManager.currentIndividualCharacterManager.characterWeapon;
                FireProjectile(wandItem.projectileItem,
                    wandItem.modelPrefab.GetComponentInChildren<ProjectileLocation>().transform.position
                + mainCharacterManager.weaponSlotManager.rightHandSlot.transform.position);
            }

        }

        public void FireProjectile(ProjectileItem projectileItem, Vector3 launchFrom)
        {

        
            GameObject projectile = Instantiate(projectileItem.projectileItem, launchFrom, mainCharacterManager.transform.rotation);

            projectile.transform.rotation = Quaternion.Euler(0, mainCharacterManager.transform.eulerAngles.y, 0);

            projectile.transform.parent = null;

           
            projectile.GetComponent<ProjectileDamageCollider>().finalDamage = projectileItem.damage + mainCharacterManager.currentIndividualCharacterManager.characterCreature.strength; 
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * projectileItem.forwardVelocity;
        }

        public void HandleAttackClose()
        {
            WeaponType currentWeaponType = mainCharacterManager.currentIndividualCharacterManager.characterWeapon.weaponType;
            if (currentWeaponType == WeaponType.Knuckle)
            {
                fistCollider.DisableDamageCollider();
            }

            else if (currentWeaponType == WeaponType.Sword)
            {
                swordCollider.DisableDamageCollider();
            }

            else
            {
                Debug.Log("nothing to do, since this is projectile weapon");
            }
        }

        

        public void AssignAttackInput()
        {
            mainCharacterManager.currentCharacterAnimationEventHandler.onEnableBaseAttack += EnableNextWeakAttack;
            mainCharacterManager.currentCharacterAnimationEventHandler.onAttackOpen += HandleAttackOpen;
            mainCharacterManager.currentCharacterAnimationEventHandler.onAttackClose += HandleAttackClose;
            mainCharacterManager.currentCharacterAnimationEventHandler.onSkillOpen += ActivateSkill;
            mainCharacterManager.currentCharacterAnimationEventHandler.onSkillClose += DeactivateSkill;
            mainCharacterManager.currentCharacterAnimationEventHandler.onQteOpen += ActivateQTE;
        }

        public void RemoveAttackInput()
        {
            mainCharacterManager.currentCharacterAnimationEventHandler.onEnableBaseAttack -= EnableNextWeakAttack;
            mainCharacterManager.currentCharacterAnimationEventHandler.onAttackOpen -= HandleAttackOpen;
            mainCharacterManager.currentCharacterAnimationEventHandler.onAttackClose -= HandleAttackClose;
            mainCharacterManager.currentCharacterAnimationEventHandler.onSkillOpen -= ActivateSkill;
            mainCharacterManager.currentCharacterAnimationEventHandler.onSkillClose -= DeactivateSkill;
            mainCharacterManager.currentCharacterAnimationEventHandler.onQteOpen -= ActivateQTE;
        }

       

        public void EnableNextWeakAttack()
        {
            
            mainCharacterManager.currentCharacterAnimatedController.anim.SetBool(canDoComboHash, true);

            if (isAttackButtonAlreadyPressed)
            {
                PressWeakAttackButton();
            }
        }

        public void PressWeakAttackButton()
        {
            isAttackButtonAlreadyPressed = true;

            if (mainCharacterManager.currentCharacterAnimatedController.anim.GetBool(canDoComboHash))
            {
        
              
                mainCharacterManager.currentCharacterAnimatedController.PlayAttackAnimation((int)mainCharacterManager.currentWeaponType);
                isAttackButtonAlreadyPressed = false;
                mainCharacterManager.currentCharacterAnimatedController.anim.SetBool(canDoComboHash, false);
            }

        }

        public void ActivateSkill()
        {
            mainCharacterManager.currentIndividualCharacterManager.characterWeapon.weaponSkill.OnSkillActivate();
        }

        public void DeactivateSkill()
        {
            mainCharacterManager.currentIndividualCharacterManager.characterWeapon.weaponSkill.OnSkillDeactivate();
        }

        public void ActivateQTE()
        {
            mainCharacterManager.currentIndividualCharacterManager.characterItemInfo.qteSkill.OnSkillActivate();
        }





        public void Roll()
        {
            mainCharacterManager.characterLocomotion.MoveRoll(); //change direction of the character
            mainCharacterManager.currentCharacterAnimatedController.EnableRootMotion();
            mainCharacterManager.currentCharacterAnimatedController.anim.SetBool(canRotateHash, false);
            mainCharacterManager.currentCharacterAnimatedController.anim.SetTrigger(rollingHash);
        }

        public void UseWeaponArt()
        {
            Debug.Log($"current character name is {mainCharacterManager.currentIndividualCharacterManager.characterItemInfo.itemName}");
            mainCharacterManager.currentCharacterAnimatedController.anim.SetBool(isAttackingHash, true);
            mainCharacterManager.currentCharacterAnimatedController.PlayTargetAnimation(mainCharacterManager.currentIndividualCharacterManager.characterWeapon.weaponArtName,
               true, 0.2f);
        }

        private void Update()
        {

        }
    }
}

