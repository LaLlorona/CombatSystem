using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class WeaponPickup : Interactable
    {
        public WeaponItem weapon;

        public override void Interact(MainCharacterManager characterManager)
        {
            base.Interact(characterManager);
            PickUpItem(characterManager);
        }

        private void PickUpItem(MainCharacterManager characterManager)
        {
            CharacterInventory characterInventory;
            CharacterLocomotion characterLocomotion;
            AnimatedController animatedController;

            characterInventory = characterManager.characterInventory;
            characterLocomotion = characterManager.characterLocomotion;
            animatedController = characterManager.currentCharacterAnimatedController;

            characterLocomotion.rigidbody.velocity = Vector3.zero;
            animatedController.PlayTargetAnimation("PickUpItem", true, 0.2f); //play animation when looting an iteam

            characterInventory.weaponsInventory.Add(weapon);
            characterManager.interactablePopupUI.SetInteractableText(weapon.itemName);
            characterManager.interactablePopupUI.SetIcon(weapon.itemIcon);


            Destroy(gameObject);

        }
    }

}
