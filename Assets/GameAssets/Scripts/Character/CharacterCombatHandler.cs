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
        CharacterStats characterStats;


        public MeleeDamageCollider swordCollider;
        public MeleeDamageCollider fistCollider;
        

        public bool isAttackButtonAlreadyPressed = false;
       

       

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
            if (currentWeaponType == WeaponType.Fist)
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
            }

            
        }

        public void HandleAttackClose()
        {
            WeaponType currentWeaponType = mainCharacterManager.currentIndividualCharacterManager.characterWeapon.weaponType;
            if (currentWeaponType == WeaponType.Fist)
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

        }

        public void RemoveAttackInput()
        {
            mainCharacterManager.currentCharacterAnimationEventHandler.onEnableBaseAttack -= EnableNextWeakAttack;
            mainCharacterManager.currentCharacterAnimationEventHandler.onAttackOpen -= HandleAttackOpen;
            mainCharacterManager.currentCharacterAnimationEventHandler.onAttackClose -= HandleAttackClose;
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





        public void Roll()
        {
            mainCharacterManager.currentCharacterAnimatedController.EnableRootMotion();
            mainCharacterManager.currentCharacterAnimatedController.anim.SetTrigger(rollingHash);
        }

        public void UseWeaponArt()
        {
            Debug.Log($"current character name is {mainCharacterManager.currentIndividualCharacterManager.characterItemInfo.itemName}");
            mainCharacterManager.currentCharacterAnimatedController.PlayTargetAnimation(mainCharacterManager.currentIndividualCharacterManager.characterWeapon.weaponArtName,
               true, 0.2f);
        }

        private void Update()
        {

        }
    }
}

