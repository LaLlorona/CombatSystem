using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KMK
{
    [CreateAssetMenu(menuName = "Curves")]
    public class Curves : ScriptableObject
    {
        public AnimationCurve SmoothInOut;
        public AnimationCurve SmoothIn;
        public AnimationCurve SmoothOut;
        public AnimationCurve Overshoot;
        public AnimationCurve OvershootMenu;
        public AnimationCurve Hill;
    }
}

