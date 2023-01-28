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
        public AnimatedController currentCharacterAnimatedController;
        public LayerMask toDetect;
        public InputReader inputReader;


        [Header("To update when changing the character")]
        public CharacterAnimationEventHandler currentCharacterAnimationEventHandler;
        public GameObject currentCharacterObject;
        public int currentCharacterIndex;
        public IndividualCharacterManager[] individualCharacterManagers;
        public IndividualCharacterManager currentIndividualCharacterManager;
        public CharacterCombatHandler characterCombatHandler;
        public WeaponType currentWeaponType;

        





        public InteractablePopupUI interactablePopupUI;
        public GameObject interactableUIGameobject;
        public GameObject itemDescriptionUIGameobject;

        // Start is called before the first frame update
        void Awake()
        {
            anim = GetComponentInChildren<Animator>();
            
            characterInventory = GetComponent<CharacterInventory>();
            characterLocomotion = GetComponent<CharacterLocomotion>();

            characterCombatHandler = GetComponent<CharacterCombatHandler>();
    
        }

        private void Start()
        {
            individualCharacterManagers = GetComponentsInChildren<IndividualCharacterManager>();
            currentIndividualCharacterManager = individualCharacterManagers[0];
            currentCharacterAnimationEventHandler = currentIndividualCharacterManager.characterAnimationEventHandler;
            currentCharacterAnimatedController = currentIndividualCharacterManager.animatedController;
            characterCombatHandler.AssignAttackInput();
            EnableCharacterWithIndex(0);
        }

        public void HideAllCharacterGameobjects()
        {
            characterCombatHandler.RemoveAttackInput();
            for (int i = 0; i < individualCharacterManagers.Length; i++)
            {
                individualCharacterManagers[i].individualCharacterGameobject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            inputReader.OnCharacterChange += EnableCharacterWithIndex;
        }

        private void OnDisable()
        {
            inputReader.OnCharacterChange -= EnableCharacterWithIndex;
        }
        public void EnableCharacterWithIndex(int index)
        {
            HideAllCharacterGameobjects();
            currentIndividualCharacterManager = individualCharacterManagers[index];

            currentIndividualCharacterManager.individualCharacterGameobject.SetActive(true);

            currentCharacterAnimatedController = currentIndividualCharacterManager.animatedController;
            currentCharacterAnimationEventHandler = currentIndividualCharacterManager.characterAnimationEventHandler;

            currentWeaponType = currentIndividualCharacterManager.characterWeapon.weaponType;

            characterCombatHandler.AssignAttackInput();
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
                        
                        if (inputReader.aInput)
                        {
                            interactablePopupUI.SetItemText(interactableObject.itemDescription);
                            itemDescriptionUIGameobject.SetActive(true);
                            interactableObject.Interact(this);
                            
                            
                            inputReader.aInput = false;
                           
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
                if (itemDescriptionUIGameobject != null && inputReader.aInput)
                {
                    itemDescriptionUIGameobject.SetActive(false);
                }
            }
        }

        public void OpenChestInteraction(Transform playerStandingPosition)
        {
            characterLocomotion.rigidbody.velocity = Vector3.zero;
            transform.position = playerStandingPosition.transform.position;
            currentCharacterAnimatedController.PlayTargetAnimation("PickUpItem", true, 0.2f);
        }

        #endregion
    }
}

