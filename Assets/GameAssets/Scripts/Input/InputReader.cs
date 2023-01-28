using UnityEngine;
using UnityEngine.Events;
using System.Collections;
//DISABLE if using old input system
using UnityEngine.InputSystem;


namespace KMK
{
    public class InputReader : MonoBehaviour
    {
        #region InputEvent Definition
        public delegate void InputEvent();
        public delegate void CharacterChangeInputEvent(int characterIndex);

        public InputEvent OnInventoryInput;
        public InputEvent OnLockonInput;
        public InputEvent OnYButtonInput;
        public InputEvent OnAttackButtonInput;
        public InputEvent OnRollInput;

        public CharacterChangeInputEvent OnCharacterChange;

        #endregion



        [Header("Input specs")]
        public UnityEvent changedInputToMouseAndKeyboard;
        public UnityEvent changedInputToGamepad;

        [Header("Enable inputs")]
        public bool enableJump = true;
        public bool enableCrouch = true;
        public bool enableSprint = true;


        [HideInInspector]
        public Vector2 axisInput;
        [HideInInspector]
        public Vector2 cameraInput = Vector2.zero;
        [HideInInspector]
        public bool jump;
        [HideInInspector]
        public bool jumpHold;
        [HideInInspector]
        public float zoom;
        [HideInInspector]
        public bool sprint;
        [HideInInspector]
        public bool crouch;

        [HideInInspector]
        public bool roll;

        public bool b_input;
        public bool aInput;
        public bool yInput;
        public bool rbInput;
        public bool rtInput;

        public bool dPadUp;
        public bool dPadDown;
        public bool dPadRight;
        public bool dPadLeft;
        public bool inventoryFlag;

        public bool comboFlag;

        private float rollInputTimer;
        [SerializeField]
        private float maxTimeHoldForRoll = 0.3f;



        private bool hasJumped = false;
        private bool skippedFrame = false;
        private bool isMouseAndKeyboard = true;
        private bool oldInput = true;

        //DISABLE if using old input system
        private MovementActions movementActions;


        /**/




        //DISABLE if using old input system
        private void Awake()
        {


            movementActions = new MovementActions();

            movementActions.Gameplay.Movement.performed += ctx => OnMove(ctx);

            movementActions.Gameplay.Jump.performed += ctx => OnJump();
            movementActions.Gameplay.Jump.canceled += ctx => JumpEnded();

            movementActions.Gameplay.Camera.performed += ctx => OnCamera(ctx);

            movementActions.Gameplay.Sprint.performed += ctx =>
            {
                OnSprint(ctx);
            };
            movementActions.Gameplay.Sprint.canceled += ctx => SprintEnded(ctx);

            movementActions.Gameplay.Roll.performed += ctx => OnRoll(ctx);

            movementActions.Gameplay.Crouch.performed += ctx => OnCrouch(ctx);
            movementActions.Gameplay.Crouch.canceled += ctx => CrouchEnded(ctx);

            movementActions.Gameplay.RB.performed += ctx => OnLightAttack(ctx);
            movementActions.Gameplay.RB.canceled += ctx => LightAttackEnded(ctx);

            movementActions.Gameplay.RT.performed += ctx => OnHeavyAttack(ctx);
            movementActions.Gameplay.RT.canceled += ctx => HeavyAttackEnded(ctx);



            movementActions.Gameplay.DPadUp.performed += ctx => OnDpadUp(ctx);
            movementActions.Gameplay.DPadUp.canceled+= ctx => OnDpadUpEnded(ctx);

            movementActions.Gameplay.DPadDown.performed += ctx => OnDpadDown(ctx);
            movementActions.Gameplay.DPadDown.canceled+= ctx => OnDpadDownEnded(ctx);

            movementActions.Gameplay.DPadRight.performed += ctx => OnDpadRight(ctx);
            movementActions.Gameplay.DPadRight.canceled+= ctx => OnDpadRightEnded(ctx);

            movementActions.Gameplay.DPadLeft.performed += ctx => OnDpadLeft(ctx);
            movementActions.Gameplay.DPadLeft.canceled+= ctx => OnDpadLeftEnded(ctx);

            movementActions.Gameplay.A.performed += ctx =>
            {
                aInput = true;
            };

            movementActions.Gameplay.A.canceled += ctx =>
            {
                aInput = false;
            };

            movementActions.UI.Inventory.performed += ctx =>
            {
                OnInventoryInput?.Invoke();
            };

            movementActions.Gameplay.LockOn.performed += ctx =>
            {
                OnLockonInput?.Invoke();
            };

            movementActions.Gameplay.Y.performed += ctx =>
            {
                OnYButtonInput?.Invoke();
            };

            movementActions.Gameplay.Y.canceled += ctx =>
            {
                
            };

            movementActions.Gameplay.BaseAttack.performed += ctx =>
            {
                OnAttackButtonInput?.Invoke();
            };

            movementActions.Gameplay.CharacterChange1.performed += ctx =>
            {
                OnCharacterChange?.Invoke(0);
              
            };

            movementActions.Gameplay.CharacterChange2.performed += ctx =>
            {
                OnCharacterChange?.Invoke(1);
            
            };

            movementActions.Gameplay.CharacterChange3.performed += ctx =>
            {
                OnCharacterChange?.Invoke(2);
            
            };



        }


        //ENABLE if using old input system
        private void Update()
        {
            /*
             
            axisInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f).normalized;

            if (enableJump)
            {
                if (Input.GetButtonDown("Jump")) OnJump();
                if (Input.GetButtonUp("Jump")) JumpEnded();
            }

            if (enableSprint) sprint = Input.GetButton("Fire3");
            if (enableCrouch) crouch = Input.GetButton("Fire1");

            GetDeviceOld();

            */
        }


        //DISABLE if using old input system
        private void GetDeviceNew(InputAction.CallbackContext ctx)
        {
            oldInput = isMouseAndKeyboard;

            if (ctx.control.device is Keyboard || ctx.control.device is Mouse) isMouseAndKeyboard = true;
            else isMouseAndKeyboard = false;

            if (oldInput != isMouseAndKeyboard && isMouseAndKeyboard) changedInputToMouseAndKeyboard.Invoke();
            else if (oldInput != isMouseAndKeyboard && !isMouseAndKeyboard) changedInputToGamepad.Invoke();
        }


        //ENABLE if using old input system
        private void GetDeviceOld()
        {
            /*

            oldInput = isMouseAndKeyboard;

            if (Input.GetJoystickNames().Length > 0) isMouseAndKeyboard = false;
            else isMouseAndKeyboard = true;

            if (oldInput != isMouseAndKeyboard && isMouseAndKeyboard) changedInputToMouseAndKeyboard.Invoke();
            else if (oldInput != isMouseAndKeyboard && !isMouseAndKeyboard) changedInputToGamepad.Invoke();

            */
        }


        #region Actions

        //DISABLE if using old input system
        public void OnMove(InputAction.CallbackContext ctx)
        {
            axisInput = ctx.ReadValue<Vector2>();
            GetDeviceNew(ctx);
        }


        public void OnJump()
        {
            if (enableJump)
            {
                jump = true;
                jumpHold = true;

                hasJumped = true;
                skippedFrame = false;
            }
        }


        public void JumpEnded()
        {
            jump = false;
            jumpHold = false;
        }



        private void FixedUpdate()
        {
            if (hasJumped && skippedFrame)
            {
                jump = false;
                hasJumped = false;
            }
            if (!skippedFrame && enableJump) skippedFrame = true;
        }



        //DISABLE if using old input system
        public void OnCamera(InputAction.CallbackContext ctx)
        {
            Vector2 pointerDelta = ctx.ReadValue<Vector2>();
            cameraInput.x += pointerDelta.x;
            cameraInput.y += pointerDelta.y;
            GetDeviceNew(ctx);
        }


        //DISABLE if using old input system
        public void OnSprint(InputAction.CallbackContext ctx)
        {
            if (enableSprint) sprint = true;
         
        }

      


        //DISABLE if using old input system
        public void SprintEnded(InputAction.CallbackContext ctx)
        {
            sprint = false;
            
        }

        public void OnRoll(InputAction.CallbackContext ctx)
        {
            OnRollInput?.Invoke();
        }


        //DISABLE if using old input system
        public void OnCrouch(InputAction.CallbackContext ctx)
        {
            if (enableCrouch) crouch = true;
        }

        public void OnDpadUp(InputAction.CallbackContext ctx)
        {
            dPadUp = true;
        }

        public void OnDpadUpEnded(InputAction.CallbackContext ctx)
        {
            dPadUp = false;
        }

        public void OnDpadDown(InputAction.CallbackContext ctx)
        {
            dPadDown = true;
        }

        public void OnDpadDownEnded(InputAction.CallbackContext ctx)
        {
            dPadDown = false;
        }


        public void OnDpadRight(InputAction.CallbackContext ctx)
        {
            dPadRight = true;
        }

        public void OnDpadRightEnded(InputAction.CallbackContext ctx)
        {
            dPadRight = false;
        }
       
        public void OnDpadLeft(InputAction.CallbackContext ctx)
        {
            dPadLeft = true;
        }

        public void OnDpadLeftEnded(InputAction.CallbackContext ctx)
        {
            dPadLeft = false;
        }



        //DISABLE if using old input system
        public void CrouchEnded(InputAction.CallbackContext ctx)
        {
            crouch = false;
        }

        private void OnLightAttack(InputAction.CallbackContext ctx)
        {
            Debug.Log("onlight attack true");
            rbInput = true;
        }

        private void OnHeavyAttack(InputAction.CallbackContext ctx)
        {
            rtInput = true;
        }

        private void LightAttackEnded(InputAction.CallbackContext ctx)
        {
            Debug.Log("onlight attack false");
            rbInput = false;
        }

        private void HeavyAttackEnded(InputAction.CallbackContext ctx)
        {
            rtInput = false;
        }

        

        #endregion


        #region Enable / Disable

        //DISABLE if using old input system
        private void OnEnable()
        {
            movementActions.Enable();
        }


        //DISABLE if using old input system
        private void OnDisable()
        {
            movementActions.Disable();
        }

        private void OnLockOn()
        {

        }

    

      

        #endregion

     
    }
}