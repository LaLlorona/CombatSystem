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



        public string lastAttack;
        public WeaponItem currentlyAttackingWeapon;

        public int tempWeaponNumber = 0;

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

        

        public void AssignAttackInput()
        {
            mainCharacterManager.currentCharacterAnimationEventHandler.onEnableBaseAttack += EnableNextWeakAttack;
            
        }

        public void RemoveAttackInput()
        {
            mainCharacterManager.currentCharacterAnimationEventHandler.onEnableBaseAttack -= EnableNextWeakAttack;
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

