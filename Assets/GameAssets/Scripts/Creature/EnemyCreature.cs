using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    
    public class EnemyCreature : Creature
    {
        public BlazeAI enemyAI;

        private void Awake()
        {
            enemyAI = GetComponent<BlazeAI>();
        }
        public override void OnDamage(Attack attack)
        {
            base.OnDamage(attack);

            if (currentHealth > 0)
            {
                enemyAI.hitStateBehaviour.GetComponent<BlazeAISpace.HitStateBehaviour>().hitDuration = attack.hitDuration;
                enemyAI.hitStateBehaviour.GetComponent<BlazeAISpace.HitStateBehaviour>().hitAnim = "Attack";
                enemyAI.Hit(MainCharacterManager.Instance.gameObject);
            }

            else if (currentHealth <= 0)
            {
                enemyAI.Death();
            }
        }

    }

}
