using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class CharacterAttack : MonoBehaviour
    {
        AnimatedController animatedController;
        CharacterInventory characterInventory;
        public InputReader input;

        private void Awake()
        {
            animatedController = GetComponentInChildren<AnimatedController>();
            characterInventory = GetComponent<CharacterInventory>();
        }
        public void HandleLightAttack(WeaponItem weapon)
        {
            animatedController.PlayTargetAnimation(weapon.oneHandLightAttack1, true, 0.2f);
        }
        public void HandleHeavyAttack(WeaponItem weapon)
        {
            animatedController.PlayTargetAnimation(weapon.oneHandHeavyAttack1, true, 0.2f);
        }

        private void Update()
        {
            if (input.rbInput)
            {
                HandleLightAttack(characterInventory.rightWeapon);
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

