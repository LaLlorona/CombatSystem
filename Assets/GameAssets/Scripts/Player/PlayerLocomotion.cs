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
        public Vector3 moveDirection;

        [HideInInspector]
        public Transform myTransform;

        [HideInInspector]
        public AnimatorHandler animatorHandler;

        public new Rigidbody rigidbody;
        public GameObject normalCamera;

        [Header("Ground and Air Detection Stats")]
        [SerializeField]
        float groundDetectionRayStartPoint = 0.5f;
        [SerializeField]
        float minimumDistanceToFall = 1f;
        [SerializeField]
        float groundDirectionRayDistance = 0.2f;

        LayerMask ignoreForGroundCheck;
        public float inAirTimer;

        [Header("Movement Stats")]
        [SerializeField]
        float movementSpeed = 5;
        [SerializeField]
        float sprintSpeed = 10f;

        [SerializeField]
        float rotationSpeed = 10;

        [SerializeField]
        float fallingSpeed = 45;

     

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            inputHandler = GetComponent<InputHandler>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            playerManager = GetComponent<PlayerManager>();
            cameraObject = Camera.main.transform;
            myTransform = transform;

            animatorHandler.Initialize();
            playerManager.isGrounded = true;
            ignoreForGroundCheck = ~(1 << 8 | 1 << 11);
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
            //if (animatorHandler.anim.GetBool(isInteractingHash))
            //{
            //    animatorHandler.UpdateAnimatorValues(0, 0, false);
            //    return;
            //}
            Debug.Log($"in handle movement, vert and horizon value is {inputHandler.vertical} , {inputHandler.horizontal}");
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

        public void HandleFalling(float delta, Vector3 moveDirection)
        {
            playerManager.isGrounded = false;
            RaycastHit hit;
            Vector3 origin = myTransform.position;
            origin.y += groundDetectionRayStartPoint;

            if (Physics.Raycast(origin,myTransform.forward, out hit, 0.4f))
            { //if  something is in front of the character, you will not move 
                Debug.Log("something is in front of the character, you will not move ");
                moveDirection = Vector3.zero;
            }

            if (playerManager.isInAir)
            {
                Debug.Log("player is in air");
                rigidbody.AddForce(-Vector3.up * fallingSpeed);
                rigidbody.AddForce(moveDirection * fallingSpeed / 5f);
            }

            Vector3 dir = moveDirection;
            dir.Normalize();
            origin += dir * groundDirectionRayDistance;

            targetPosition = myTransform.position;

            Debug.DrawRay(origin, -Vector3.up * minimumDistanceToFall, Color.red, 0.1f, false);

            if (Physics.Raycast(origin, -Vector3.up, out hit, minimumDistanceToFall, ignoreForGroundCheck))
            {
                Debug.Log("player is on the ground");
                normalVector = hit.normal;
                Vector3 targetPos = hit.point;
                playerManager.isGrounded = true;
                targetPosition.y = targetPos.y;

                if (playerManager.isInAir)
                {
                    Debug.Log("ray cast hit, but player is in air");
                    if (inAirTimer > 0.5f)
                    {
                        Debug.Log($"you were in air fir {inAirTimer} seconds");
                        animatorHandler.PlayTargetAnimation("Land", true);
                        inAirTimer = 0;

                    }

                    else
                    {
                        animatorHandler.PlayTargetAnimation("Locomotion", false);
                        inAirTimer = 0;
                    }

                    playerManager.isInAir = false;

                }
            }
            else
            {
                Debug.Log("player left the platform");
                if(playerManager.isGrounded)
                {
                    playerManager.isGrounded = false;
                }

                if(playerManager.isInAir == false)
                {
                    if (playerManager.isInteracting == false)
                    {
                        animatorHandler.PlayTargetAnimation("Falling", true);
                    }

                    Vector3 vel = rigidbody.velocity;
                    vel.Normalize();
                    rigidbody.velocity = vel * (movementSpeed / 2);
                    playerManager.isInAir = true;
                }
            }

            if (playerManager.isGrounded)
            {
                Debug.Log("player is on ground");
                if(playerManager.isInteracting || inputHandler.moveAmount > 0)
                {
                    myTransform.position = Vector3.Lerp(myTransform.position, targetPosition, Time.deltaTime);
                }

                else
                {
                    myTransform.position = targetPosition;
                }
            }


        }

        #endregion
    }

}
