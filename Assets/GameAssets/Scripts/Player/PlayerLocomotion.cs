using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KMK.AnimationNameDefine;

namespace KMK
{
    public class PlayerLocomotion : MonoBehaviour
    {
        PlayerManager playerManager;
        Transform cameraObject;
        InputHandler inputHandler;
        Vector3 moveDirection;

        [HideInInspector]
        public Transform myTransform;

        [HideInInspector]
        public AnimatorHandler animatorHandler;

        public new Rigidbody rigidbody;
        public GameObject normalCamera;

        [Header("Movement Stats")]
        [SerializeField]
        float movementSpeed = 5;
        [SerializeField]
        float sprintSpeed = 10f;

        [SerializeField]
        float rotationSpeed = 10;

     

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            inputHandler = GetComponent<InputHandler>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            playerManager = GetComponent<PlayerManager>();
            cameraObject = Camera.main.transform;
            myTransform = transform;

            animatorHandler.Initialize();
        }

        private void Update()
        {
          

           


        }

        #region Handle movement and rotation of the player
        Vector3 normalVector;
        Vector3 targetPosition;

        private void HandleRotation(float delta)
        {
            
            Vector3 targetDir = Vector3.zero;
            float moveOverride = inputHandler.moveAmount;

            targetDir = cameraObject.forward * inputHandler.vertical;
            targetDir += cameraObject.right * inputHandler.horizontal;

            targetDir.Normalize();

            targetDir.y = 0;

            if (targetDir == Vector3.zero)
            {
                targetDir = myTransform.forward;
            }

            float rs = rotationSpeed;
            Quaternion tr = Quaternion.LookRotation(targetDir);

            Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);

            myTransform.rotation = targetRotation;
        }

       

        

        public void HandleMovement(float delta)
        {
            if (animatorHandler.anim.GetBool(isInteractingHash))
            {
                animatorHandler.UpdateAnimatorValues(0, 0, false);
                return;
            }
            moveDirection = cameraObject.forward * inputHandler.vertical;
            moveDirection += cameraObject.right * inputHandler.horizontal;
            //moveDirection.Normalize();
            moveDirection.y = 0;


            Debug.Log(normalVector);
            Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
            projectedVelocity.Normalize();

            if (inputHandler.sprintFlag)
            {
                projectedVelocity *= sprintSpeed;
               
            }
            else
            {
                projectedVelocity *= movementSpeed;
                
            }
            
            rigidbody.velocity = projectedVelocity;

            animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0, playerManager.isSprinting);

            if (animatorHandler.canRotate)
            {
                HandleRotation(delta);
            }
        }

        public void HandleRollingAndSprinting(float delta)
        {
            //Debug.Log(inputHandler.rollFlag);
            if (animatorHandler.anim.GetBool(isInteractingHash))
            {
                return;
            }

            if (inputHandler.rollFlag)
            {
                
                if (inputHandler.moveAmount > 0)
                {
                    moveDirection = cameraObject.forward * inputHandler.vertical;
                    moveDirection += cameraObject.right * inputHandler.horizontal;
                    animatorHandler.PlayTargetAnimation("Rolling", true);
                    moveDirection.y = 0;

                    Debug.Log(moveDirection);



                    Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                    myTransform.rotation = rollRotation;
                }
                else
                {
                    animatorHandler.PlayTargetAnimation("Backstep", true);
                }



            }
           
        }

        #endregion
    }

}
