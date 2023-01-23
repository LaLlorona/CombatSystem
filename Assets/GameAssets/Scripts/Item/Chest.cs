using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class Chest : Interactable
    {
        Animator animator;

        public WeaponItem weapon;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public Transform playerStandingPosition;
        public override void Interact(MainCharacterManager characterManager)
        {
            base.Interact(characterManager);

            //Rotate our player towards the chest
            Vector3 rotationDirection = transform.position - characterManager.transform.position;

            rotationDirection.y = 0;
            rotationDirection.Normalize();

            Quaternion tr = Quaternion.LookRotation(rotationDirection);

            characterManager.transform.rotation = tr;
            characterManager.OpenChestInteraction(playerStandingPosition);


            CharacterInventory characterInventory;
            CharacterLocomotion characterLocomotion;
            AnimatedController animatedController;

            characterInventory = characterManager.characterInventory;
            characterLocomotion = characterManager.characterLocomotion;
            animatedController = characterManager.animatedController;

            characterLocomotion.rigidbody.velocity = Vector3.zero;
            animatedController.PlayTargetAnimation("PickUpItem", true, 0.2f); //play animation when looting an iteam

            characterInventory.weaponsInventory.Add(weapon);
            characterManager.interactablePopupUI.SetInteractableText(weapon.itemName);
            characterManager.interactablePopupUI.SetIcon(weapon.itemIcon);
            animator.Play("Chest Open");

            Destroy(this);
            
            //Lock the player's transform to a certain point of the chest

            //open the chest lid, and animate the player

            //spawn an item inside the chest 
        }

    
    }

}
