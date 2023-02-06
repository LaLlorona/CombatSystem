using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    [CreateAssetMenu(menuName = "CrowdControls")]
    public class CrowdControl : ScriptableObject
    {
        
        public CrowdControlType crowdControlType;
        public float duration;
        public float ccValuePercent;
    }

}
