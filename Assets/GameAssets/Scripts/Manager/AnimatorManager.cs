using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KMK.AnimationNameDefine;

namespace KMK
{
    public class AnimatorManager : MonoBehaviour
    {
        public Animator anim;
        public bool rootMotionEnabled = false;
        public bool canRotate = true;
        public bool canDoCombo = true;
        public bool canBeInterrupted = true;
        public bool isAttacking = false;
        public void PlayTargetAnimation(string targetAnim, bool isRootMotion, float crossFadeTime, bool setCanBeInterrupted = true)
        {
            if (!canBeInterrupted)
            {
                return;
            }   
            anim.applyRootMotion = isRootMotion;
            
            
            anim.SetBool(isRootMotionHash, isRootMotion);
            anim.SetBool(canBeInterruptedHash, setCanBeInterrupted);
            anim.CrossFade(targetAnim, crossFadeTime);

            rootMotionEnabled = isRootMotion;

        }
    }
}

