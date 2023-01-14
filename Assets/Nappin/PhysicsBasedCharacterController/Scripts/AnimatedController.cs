using UnityEngine;
using static KMK.AnimationNameDefine;

namespace KMK
{
    public class AnimatedController : MonoBehaviour
    {
        [Header("References")]
        public CharacterManager characterManager;
        public Rigidbody rigidbodyCharacter;
        [SerializeField] LayerMask groundMask;
        [Space(10)]

        [Header("Animation specifics")]
        public float velocityAnimationMultiplier = 1f;
        public bool lockRotationOnWall = true;
        public float groundCheckerThrashold = 0.4f;
        public float climbThreshold = 0.5f;

        public float sprintMultiplier = 2.0f;


        private Animator anim;
        private float originalColliderHeight;

        public bool rootMotionEnabled = false;


        /**/


        private void Awake()
        {
            anim = this.GetComponent<Animator>();
        }


        private void Start()
        {
            originalColliderHeight = characterManager.GetOriginalColliderHeight();
        }


        private void Update()
        {
            rootMotionEnabled = anim.GetBool(isRootMotionHash);
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

        public void PlayTargetAnimation(string targetAnim, bool isRootMotion, float crossFadeTime)
        {
            anim.applyRootMotion = isRootMotion;
            anim.SetBool(isRootMotionHash, isRootMotion);
            anim.CrossFade(targetAnim, crossFadeTime);
            rootMotionEnabled = isRootMotion;

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
    }
}