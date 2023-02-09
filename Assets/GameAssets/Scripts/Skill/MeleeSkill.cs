using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KMK{
    public class MeleeSkill : Skill
    {
        public GameObject damagePrefab;
        private MeleeDamageCollider meleeDamageCollider;

        public override void OnSkillActivate()
        {
            base.OnSkillActivate();
            
            skillTransform = MainCharacterManager.Instance.transform.position;
            GameObject damageObject = Instantiate(damagePrefab, skillTransform, Quaternion.identity);

           
            meleeDamageCollider = damageObject.GetComponent<MeleeDamageCollider>();
            meleeDamageCollider.EnableDamageCollider();
            meleeDamageCollider.damage = skillFinalDamage;

            Destroy(meleeDamageCollider, 0.25f);
        }
    }
}
