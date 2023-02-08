using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class Skill : MonoBehaviour
    {
        [Header("Skill Type")]
        SkillType skillType;

        public float mpCost;
        public float skillDamage;
        public Vector3 skillTransform;


        public virtual void OnSkillActivate()
        {

        }

        public virtual void OnSkillDeactivate()
        {

        }


    }

}
