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

        //[Header("CharacterSpecificReference")]
        //public AnimatedController animatedController;
        //public CharacterAnimationEventHandler characterAnimationEventHandler;

        public string lastAttack;
        public WeaponItem currentlyAttackingWeapon;

        public int tempWeaponNumber = 0;

        public bool isAttackButtonAlreadyPressed = false;
       

       

        private void Awake()
        {
            //animatedController = GetComponentInChildren<AnimatedController>();
            characterInventory = GetComponent<CharacterInventory>();
            mainCharacterManager = GetComponent<MainCharacterManager>();
            //characterStats = GetComponent<CharacterStats>();
            //characterAnimationEventHandler = GetComponentInChildren<CharacterAnimationEventHandler>();
        }

        private void OnEnable()
        {
            

            input.OnAttackButtonInput += PressWeakAttackButton;
            input.OnRollInput += Roll;

            //AssignAttackInput();
            
        }

        private void OnDisable()
        {
        
            input.OnAttackButtonInput -= PressWeakAttackButton;
            input.OnRollInput -= Roll;
            //RemoveAttackInput();
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


        public void ReduceStaminaOnAttack() {
            characterStats.ReduceStamina(currentlyAttackingWeapon.baseStaminaDrain * currentlyAttackingWeapon.lightAttackMultiplier);
        }

        public void Roll()
        {
            mainCharacterManager.currentCharacterAnimatedController.EnableRootMotion();
            mainCharacterManager.currentCharacterAnimatedController.anim.SetTrigger(rollingHash);
        }

        private void Update()
        {

        }
    }
}

