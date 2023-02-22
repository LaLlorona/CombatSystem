using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace  KMK
{
    public class EnemyMeleeAttackBehavior : EnemyAttackBehavior
    {
        public EnemyMeleeDamageCollider damageCollider;


        private void Start()
        {
            enemyCreature = GetComponent<Creature>();
            enemyCreature.onCreatureDeath += damageCollider.DisableDamageCollider;
        }

        private void OnDestroy()
        {
            enemyCreature.onCreatureDeath -= damageCollider.DisableDamageCollider;
        }
        
        public override void SendVisualSignBeforeAttack()
        {
            base.SendVisualSignBeforeAttack();
            StartCoroutine(AttackAfterDesignatedTime(attackSignSendTime));
        }
        IEnumerator AttackAfterDesignatedTime(float designatedTime)
        {


            yield return new WaitForSeconds(designatedTime);
            if (enemyCreature.isAlive)
            {
                damageCollider.EnableDamageCollider();
            }
            
            yield return new WaitForSeconds(attackDurationTime);
            damageCollider.DisableDamageCollider();
        }
        

        


        
    }

}
