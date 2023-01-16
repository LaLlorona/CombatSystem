using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class CharacterAttack : MonoBehaviour
    {
        AnimatedController animatedController;
        CharacterInventory characterInventory;
        CharacterManager characterManager;
        public InputReader input;

        public string lastAttack;

        private void Awake()
        {
            animatedController = GetComponentInChildren<AnimatedController>();
            characterInventory = GetComponent<CharacterInventory>();
            characterManager = GetComponent<CharacterManager>();
        }

        public void HandleWeaponCombo(WeaponItem weapon)
        {
            Debug.Log("handle wewapon combo");
            if (input.comboFlag)
            {
                Debug.Log("combo flag is true");
                animatedController.anim.SetBool("CanDoCombo", false);
                if (lastAttack == weapon.oneHandLightAttack1)
                {
                    Debug.Log("anim to play is" + weapon.oneHandLightAttack2);
                    animatedController.PlayTargetAnimation(weapon.oneHandLightAttack2, true, 0.2f);
                }
            }
            
        }
        public void HandleLightAttack(WeaponItem weapon)
        {
            
            animatedController.PlayTargetAnimation(weapon.oneHandLightAttack1, true, 0.2f);
            lastAttack = weapon.oneHandLightAttack1;
        }
        public void HandleHeavyAttack(WeaponItem weapon)
        {
            animatedController.PlayTargetAnimation(weapon.oneHandHeavyAttack1, true, 0.2f);
            lastAttack = weapon.oneHandHeavyAttack1;
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

                HandleHeavyAttack(characterInventory.rightWeapon);
                input.rtInput = false;
            }
        }
    }
}

