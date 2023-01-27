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
        public void PlayTargetAnimation(string targetAnim, bool isRootMotion, float crossFadeTime)
        {
            
            anim.applyRootMotion = isRootMotion;
            anim.SetBool(canRotateHash, false);
            anim.SetBool(isRootMotionHash, isRootMotion);
            anim.CrossFade(targetAnim, crossFadeTime);
            rootMotionEnabled = isRootMotion;

        }
    }
}

