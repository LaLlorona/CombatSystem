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
        public float skillBaseDamage;

        [HideInInspector]
        public float skillFinalDamage;

        [HideInInspector]
        public Vector3 skillTransform;


        public virtual void OnSkillActivate()
        {
            skillFinalDamage = skillBaseDamage;
            Debug.Log($"skill Damage before add is {skillFinalDamage}");
            
            skillFinalDamage = skillBaseDamage + MainCharacterManager.Instance.currentIndividualCharacterManager.characterCreature.strength;
            Debug.Log($"skill Damage after add is {skillFinalDamage}");
        }

        public virtual void OnSkillDeactivate()
        {

        }


    }

}
