using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class ProjectileSkill : Skill
    {
        
        public ProjectileItem projectileItem;


        public override void OnSkillActivate()
        {
            base.OnSkillActivate();
            FireProjectile(projectileItem, MainCharacterManager.Instance.transform.position);
        }
        public void FireProjectile(ProjectileItem projectileItem, Vector3 launchFrom)
        {


            GameObject projectile = Instantiate(projectileItem.projectileItem, launchFrom, MainCharacterManager.Instance.transform.rotation);

            projectile.transform.rotation = Quaternion.Euler(0, MainCharacterManager.Instance.transform.eulerAngles.y, 0);

            projectile.transform.parent = null;


            projectile.GetComponent<ProjectileDamageCollider>().finalDamage = projectileItem.damage + MainCharacterManager.Instance.currentIndividualCharacterManager.characterCreature.strength;
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * projectileItem.forwardVelocity;
        }

    }

}
