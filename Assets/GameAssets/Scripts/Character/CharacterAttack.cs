using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        [Header("Attack Animations")]
        string oneHandLightAttack1 = "OneHandLightAttack1";
        string oneHandLightAttack2 = "OneHandLightAttack2";
        string oneHandHeavyAttack1 = "OneHandHeavyAttack1";
        string oneHandHeavyAttack2 = "OneHandHeavyAttack2";

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
            characterAnimationEventHandler.onAttackStaminaDrain += ReduceStaminaOnAttack;
        }

        private void OnDisable()
        {
            characterAnimationEventHandler.onAttackStaminaDrain -= ReduceStaminaOnAttack;
        }

        public void HandleWeaponCombo(WeaponItem weapon)
        {
            Debug.Log("handle wewapon combo");
            if (input.comboFlag)
            {
                Debug.Log("combo flag is true");
                animatedController.anim.SetBool("CanDoCombo", false);
                if (lastAttack == oneHandLightAttack1)
                {
                    Debug.Log("anim to play is" + oneHandLightAttack2);
                    animatedController.PlayTargetAnimation(oneHandLightAttack2, true, 0.2f);
                }
            }
            
        }
        public void HandleLightAttack(WeaponItem weapon)
        {
            currentlyAttackingWeapon = weapon;
            animatedController.PlayTargetAnimation(oneHandLightAttack1, true, 0.2f);
            lastAttack = oneHandLightAttack1;
        }
        public void HandleHeavyAttack(WeaponItem weapon)
        {
            currentlyAttackingWeapon = weapon;
            animatedController.PlayTargetAnimation(oneHandHeavyAttack1, true, 0.2f);
            lastAttack = oneHandHeavyAttack1;
        }

        public void ReduceStaminaOnAttack() {
            characterStats.ReduceStamina(currentlyAttackingWeapon.baseStaminaDrain * currentlyAttackingWeapon.lightAttackMultiplier);
        }

        private void Update()
        {
            if (input.rbInput)
            {
                if (characterManager.canDoCombo)
                {
                    
                    input.comboFlag = true;
                    HandleWeaponCombo(characterInventory.rightWeapon);
                    input.comboFlag = false;
                }

                else
                {
                    if (characterManager.canDoCombo || animatedController.rootMotionEnabled)
                    {
                        return;
                    }
                    Debug.Log("first attack");
                    HandleLightAttack(characterInventory.rightWeapon);
                    
                }
                input.rbInput = false;


            }

            if (input.rtInput)
            {
                if (characterManager.canDoCombo || animatedController.rootMotionEnabled)
                {
                    return;
                }
                HandleHeavyAttack(characterInventory.rightWeapon);
                input.rtInput = false;
            }
        }
    }
}

