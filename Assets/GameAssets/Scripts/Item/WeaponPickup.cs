using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class WeaponPickup : Interactable
    {
        public WeaponItem weapon;

        public override void Interact(CharacterManager characterManager)
        {
            base.Interact(characterManager);
            PickUpItem(characterManager);
        }

        private void PickUpItem(CharacterManager characterManager)
        {
            CharacterInventory characterInventory;
            CharacterLocomotion characterLocomotion;
            AnimatedController animatedController;

            characterInventory = characterManager.characterInventory;
            characterLocomotion = characterManager.characterLocomotion;
            animatedController = characterManager.animatedController;

            characterLocomotion.rigidbody.velocity = Vector3.zero;
            animatedController.PlayTargetAnimation("PickUpItem", true, 0.2f); //play animation when looting an iteam

            characterInventory.weaponsInventory.Add(weapon);

            Destroy(gameObject);

        }
    }

}
