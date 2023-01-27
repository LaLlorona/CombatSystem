using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KMK.AnimationNameDefine;

namespace KMK
{
    public class CharacterAttack : MonoBehaviour
    {
        AnimatedController animatedController;
        CharacterInventory characterInventory;
        MainCharacterManager characterManager;
        public InputReader input;
        CharacterStats characterStats;

        CharacterAnimationEventHandler characterAnimationEventHandler;

        public string lastAttack;
        public WeaponItem currentlyAttackingWeapon;

        public int tempWeaponNumber = 0;

        public bool isAttackButtonAlreadyPressed = false;
       

       

        private void Awake()
        {
            animatedController = GetComponentInChildren<AnimatedController>();
            characterInventory = GetComponent<CharacterInventory>();
            characterManager = GetComponent<MainCharacterManager>();
            characterStats = GetComponent<CharacterStats>();
            characterAnimationEventHandler = GetComponentInChildren<CharacterAnimationEventHandler>();
        }

        private void OnEnable()
        {
            

            input.OnAttackButtonInput += PressWeakAttackButton;
            input.OnRollInput += Roll;

            characterAnimationEventHandler.onEnableBaseAttack += EnableNextWeakAttack;
            
        }

        private void OnDisable()
        {
        
            input.OnAttackButtonInput -= PressWeakAttackButton;
            input.OnRollInput -= Roll;
            characterAnimationEventHandler.onEnableBaseAttack -= EnableNextWeakAttack;
        }

        public void EnableNextWeakAttack()
        {
            
            animatedController.anim.SetBool(canDoComboHash, true);

            if (isAttackButtonAlreadyPressed)
            {
                PressWeakAttackButton();
            }
        }

        public void PressWeakAttackButton()
        {
            isAttackButtonAlreadyPressed = true;

            if (animatedController.anim.GetBool(canDoComboHash))
            {
                animatedController.PlayAttackAnimation(tempWeaponNumber);
                isAttackButtonAlreadyPressed = false;
                animatedController.anim.SetBool(canDoComboHash, false);
            }

        }


        public void ReduceStaminaOnAttack() {
            characterStats.ReduceStamina(currentlyAttackingWeapon.baseStaminaDrain * currentlyAttackingWeapon.lightAttackMultiplier);
        }

        public void Roll()
        {
            animatedController.EnableRootMotion();
            animatedController.anim.SetTrigger(rollingHash);
        }

        private void Update()
        {

        }
    }
}

