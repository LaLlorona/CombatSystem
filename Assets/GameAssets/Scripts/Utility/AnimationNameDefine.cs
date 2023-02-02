
using UnityEngine;

namespace KMK
{
    public class AnimationNameDefine
    {
        public static readonly int rollingHash = Animator.StringToHash("Rolling");
        public static readonly int isRootMotionHash = Animator.StringToHash("IsRootMotion");
        public static readonly int isInteractingHash = Animator.StringToHash("IsInteracting");
        public static readonly int canDoComboHash = Animator.StringToHash("CanDoCombo");
        public static readonly int canRotateHash = Animator.StringToHash("CanRotate");
        public static readonly int canAttackHash = Animator.StringToHash("CanAttack");
        public static readonly int weaponNumberHash = Animator.StringToHash("WeaponNumber");
        public static readonly int canBeInterruptedHash = Animator.StringToHash("CanBeInterrupted");
        public static readonly int isAttackingHash = Animator.StringToHash("IsAttacking");
    }

}
