using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KMK
{
    public class AreaSkill : Skill
    {

        public GameObject damageAreaPrefab;
        private AreaDamageCollider areaDamageCollider;
        public float skillDuration = 10f;
        public float destroyTimeGapAfterFinishCollider = 2f;
        public override void OnSkillActivate()
        {
            base.OnSkillActivate();
            skillTransform = MainCharacterManager.Instance.transform.position;
            GameObject damageArea = Instantiate(damageAreaPrefab, skillTransform, Quaternion.identity);
            areaDamageCollider = damageArea.GetComponent<AreaDamageCollider>();
            areaDamageCollider.damage = skillFinalDamage;
            
            areaDamageCollider.StartDamageCoroutine();

            Destroy(damageArea, skillDuration);

            //StartCoroutine(DestroyAfterDuration(damageArea));
        }

        //IEnumerator DestroyAfterDuration(GameObject damageArea)
        //{
        //    yield return new WaitForSeconds(skillDuration);
        //    areaDamageCollider.DisableDamageCollider();
        //    yield return new WaitForSeconds(destroyTimeGapAfterFinishCollider);
            
        //    Destroy(damageArea);
        //}

        
    }

}
