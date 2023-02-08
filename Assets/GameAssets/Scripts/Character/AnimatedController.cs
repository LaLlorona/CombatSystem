using UnityEngine;
using static KMK.AnimationNameDefine;

namespace KMK
{
    public class AnimatedController : AnimatorManager
    {
        [Header("References")]
        public CharacterLocomotion characterManager;
        public Rigidbody rigidbodyCharacter;
        public CharacterAnimationEventHandler characterAnimationEventHandler;


        [SerializeField] LayerMask groundMask;
        [Space(10)]

        [Header("Animation specifics")]
        public float velocityAnimationMultiplier = 1f;
        public bool lockRotationOnWall = true;
        public float groundCheckerThrashold = 0.4f;
        public float climbThreshold = 0.5f;

        public float sprintMultiplier = 2.0f;


        
        private float originalColliderHeight;

        


        /**/


        private void Awake()
        {
            anim = this.GetComponent<Animator>();
            characterAnimationEventHandler = GetComponent<CharacterAnimationEventHandler>();
        }

        private void OnEnable()
        {

            characterAnimationEventHandler.onAttackOpen += DisableRotate;
            characterAnimationEventHandler.onSkillOpen += DisableRotate;
        }

        private void OnDisable()
        {

            characterAnimationEventHandler.onAttackOpen -= DisableRotate;
            characterAnimationEventHandler.onSkillOpen -= DisableRotate;
        }

        public void EnableRootMotion()
        {
            anim.SetBool(isRootMotionHash, true);
        }

        public void EnableRotate()
        {
            anim.SetBool(canRotateHash, true);
        }

        public void DisableRotate()
        {
            anim.SetBool(canRotateHash, false);
        }

        public void PlayAttackAnimation(int weaponNumber)
        {
            anim.SetBool(isRootMotionHash, true);
            anim.SetBool(canRotateHash, true);
            anim.SetBool(isAttackingHash, true);
            anim.SetInteger(weaponNumberHash, weaponNumber);
            anim.SetTrigger(canAttackHash);
        }

        

        private void Start()
        {
            originalColliderHeight = characterManager.GetOriginalColliderHeight();
        }


        private void Update()
        {
            rootMotionEnabled = anim.GetBool(isRootMotionHash);
            canRotate = anim.GetBool(canRotateHash);
            canDoCombo = anim.GetBool(canDoComboHash);
            canBeInterrupted = anim.GetBool(canBeInterruptedHash);
            isAttacking = anim.GetBool(isAttackingHash);
            


            anim.SetFloat("velocity", characterManager.axisInput.sqrMagnitude * (characterManager.GetSprint() ? sprintMultiplier : 1.0f), 0.2f,Time.deltaTime);

            anim.SetBool("isGrounded", CheckAnimationGrounded());

            anim.SetBool("isJump", characterManager.GetJumping());

            anim.SetBool("isTouchWall", characterManager.GetTouchingWall());
            if (lockRotationOnWall) characterManager.SetLockRotation(characterManager.GetTouchingWall());

            anim.SetBool("isClimb", characterManager.GetTouchingWall() && rigidbodyCharacter.velocity.y > climbThreshold);

            anim.SetBool("isCrouch", characterManager.GetCrouching());

            
        }


        private bool CheckAnimationGrounded()
        {
            return Physics.CheckSphere(characterManager.transform.position - new Vector3(0, originalColliderHeight / 2f, 0), groundCheckerThrashold, groundMask);
        }

        
        private void OnAnimatorMove()
        {
            if (!rootMotionEnabled)
            {
                return;
            }

            float delta = Time.deltaTime;
            characterManager.rigidbody.drag = 0;
            Vector3 deltaPosition = anim.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            characterManager.rigidbody.velocity = velocity;
        }

        public void EnableCombo()
        {
            anim.SetBool(canDoComboHash,true);
        }

        public void DisableCombo()
        {
            anim.SetBool(canDoComboHash, false);
        }

    }
}