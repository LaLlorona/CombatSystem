using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KMK.AnimationNameDefine;

namespace KMK
{
    public class MainCharacterManager : Singleton<MainCharacterManager>
    {
        private const int INITIAL_CHARACTER_INDEX = -1;
        public bool isInteracting;
        public bool canDoCombo;
        public Animator anim;
        public CharacterInventory characterInventory;
        public CharacterLocomotion characterLocomotion;
        public AnimatedController currentCharacterAnimatedController;
        public WeaponSlotManager weaponSlotManager;
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

        public GameObject targetEnemy;

        public UIManager uiManager;


        public InteractablePopupUI interactablePopupUI;
        public GameObject interactableUIGameobject;
        public GameObject itemDescriptionUIGameobject;
        
        #region Events
        public delegate void MainCharacterEvent(int index);

        public MainCharacterEvent onCharacterChange;

        
        #endregion

        // Start is called before the first frame update
        public override void Awake()
        {
            base.Awake();
            anim = GetComponentInChildren<Animator>();

            characterInventory = GetComponent<CharacterInventory>();
            characterLocomotion = GetComponent<CharacterLocomotion>();

            characterCombatHandler = GetComponent<CharacterCombatHandler>();
            weaponSlotManager = GetComponent<WeaponSlotManager>();
        }

        
        private void Start()
        {
            individualCharacterManagers = GetComponentsInChildren<IndividualCharacterManager>();
            for (int i = 0; i < individualCharacterManagers.Length; i++)
            {
                individualCharacterManagers[i].characterIndex = i;
            }
            currentIndividualCharacterManager = individualCharacterManagers[0];
            currentCharacterAnimationEventHandler = currentIndividualCharacterManager.characterAnimationEventHandler;
            currentCharacterAnimatedController = currentIndividualCharacterManager.animatedController;
            characterCombatHandler.AssignAttackInput();

            currentCharacterIndex = INITIAL_CHARACTER_INDEX;
            EnableCharacterWithIndex(0);
            currentCharacterIndex = 0;
            
            //event subscription
            
        }

        public void HideAllCharacterGameobjects()
        {
            characterCombatHandler.RemoveAttackInput();
            for (int i = 0; i < individualCharacterManagers.Length; i++)
            {
                individualCharacterManagers[i].individualCharacterGameobject.SetActive(false);
                individualCharacterManagers[i].characterCreature.isCharacterActive = false;
            }
        }

        public void SetCharacterInvincible()
        {
            currentIndividualCharacterManager.characterCreature.canTakeDamage = false;
        }

        private void OnEnable()
        {
            inputReader.OnCharacterChange += EnableCharacterWithIndex;
            inputReader.onEmoteInput += PlayEmote;
        }

        private void OnDisable()
        {
            inputReader.OnCharacterChange -= EnableCharacterWithIndex;
            inputReader.onEmoteInput -= PlayEmote;
        }
        public void EnableCharacterWithIndex(int index)
        {
            if (currentCharacterIndex == index || !individualCharacterManagers[index].canChangeCharacter)
            {
                return;
            }
            HideAllCharacterGameobjects();
            
            
            
            currentCharacterIndex = index;
            currentIndividualCharacterManager = individualCharacterManagers[index];

            currentIndividualCharacterManager.individualCharacterGameobject.SetActive(true);

            currentCharacterAnimatedController = currentIndividualCharacterManager.animatedController;
            currentCharacterAnimationEventHandler = currentIndividualCharacterManager.characterAnimationEventHandler;

            currentWeaponType = currentIndividualCharacterManager.characterWeapon.weaponType;

            characterCombatHandler.AssignAttackInput();
            
            currentIndividualCharacterManager.BeginCharacterChangeTimer();

            currentIndividualCharacterManager.characterCreature.SetCharacterActive();

            weaponSlotManager.LoadWeaponOnHand(currentIndividualCharacterManager.characterWeapon);

            uiManager.SetHPUI();
            uiManager.SetMPUI();

            characterCombatHandler.UpdateDamageColliderInformation(currentIndividualCharacterManager);

            characterCombatHandler.PlayQTEAnimationOnChange(index);
            
            characterCombatHandler.UpdateAttackAdditionalEffectChecker();
            
            onCharacterChange?.Invoke(index);
            
            

            
            //uiManager.SetMPUI();


            

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

        public void PlayEmote()
        {
            currentCharacterAnimatedController.PlayTargetAnimation("Emote",
                false, 0.2f);
            
            GameManager.Instance.HandleGameEndingUI();
            
        }
    }
}

