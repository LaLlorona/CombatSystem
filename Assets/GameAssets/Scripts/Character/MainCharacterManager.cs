using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KMK.AnimationNameDefine;

namespace KMK
{
    public class MainCharacterManager : CharacterManager
    {
        public bool isInteracting;
        public bool canDoCombo;
        public Animator anim;
        public CharacterInventory characterInventory;
        public CharacterLocomotion characterLocomotion;
        public AnimatedController animatedController;
        public LayerMask toDetect;
        public InputReader input;

        public GameObject currentCharacterObject;
        public int currentCharacterIndex;
        public CharacterModelChanger characterModelChanger;


        

        
        public InteractablePopupUI interactablePopupUI;
        public GameObject interactableUIGameobject;
        public GameObject itemDescriptionUIGameobject;

        // Start is called before the first frame update
        void Awake()
        {
            anim = GetComponentInChildren<Animator>();
            
            characterInventory = GetComponent<CharacterInventory>();
            characterLocomotion = GetComponent<CharacterLocomotion>();
            animatedController = GetComponentInChildren<AnimatedController>();
            characterModelChanger = GetComponentInChildren<CharacterModelChanger>();
    
        }

        // Update is called once per frame
        void Update()
        {
            canDoCombo = anim.GetBool(canDoComboHash);
            CheckForInteractableObject();

            Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        }

        #region Player Interaction
        public void CheckForInteractableObject()
        {
            RaycastHit hit;
            
            if (Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 10f, toDetect))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.CompareTag("Interactable"))
                {
                    Interactable interactableObject = hit.collider.GetComponent<Interactable>();

                    if(interactableObject != null)
                    {
                        string interactableText = interactableObject.interactableText;
                        //SET UI to interactable text;
                        interactableUIGameobject.SetActive(true);
                        interactablePopupUI.SetInteractableText(interactableText);
                        
                        if (input.aInput)
                        {
                            interactablePopupUI.SetItemText(interactableObject.itemDescription);
                            itemDescriptionUIGameobject.SetActive(true);
                            interactableObject.Interact(this);
                            
                            
                            input.aInput = false;
                           
                        }
                    }
                }
            }
            else
            {
               
                if (interactableUIGameobject != null)
                {
                    interactableUIGameobject.SetActive(false);
                }
                if (itemDescriptionUIGameobject != null && input.aInput)
                {
                    itemDescriptionUIGameobject.SetActive(false);
                }
            }
        }

        public void OpenChestInteraction(Transform playerStandingPosition)
        {
            characterLocomotion.rigidbody.velocity = Vector3.zero;
            transform.position = playerStandingPosition.transform.position;
            animatedController.PlayTargetAnimation("PickUpItem", true, 0.2f);
        }

        #endregion
    }
}

