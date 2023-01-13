using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KMK.AnimationNameDefine;

namespace KMK{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        
        Animator anim;

        CameraHandler cameraHandler;

        PlayerLocomotion playerLocomotion;

        [Header("Player Flags")]
        public bool isInteracting;
        public bool isSprinting;

       

        // Start is called before the first frame update
        void Start()
        {
            cameraHandler = CameraHandler.singleton;
            inputHandler = GetComponent<InputHandler>();
            anim = GetComponentInChildren<Animator>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }

        // Update is called once per frame
        void Update()
        {
            isInteracting = anim.GetBool(isInteractingHash);
            

            float delta = Time.deltaTime;

            if (cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
            }

           

            inputHandler.TickInput(delta);

            
            playerLocomotion.HandleMovement(delta);
            playerLocomotion.HandleRollingAndSprinting(delta);

        }

        private void LateUpdate()
        {
            inputHandler.rollFlag = false;
            inputHandler.sprintFlag = false;
            isSprinting = inputHandler.b_input;
        }


    }

}
