using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    
    public class EnemyCreature : Creature
    {
        public BlazeAI enemyAI;
        BlazeAISpace.HitStateBehaviour hitStateBehaviour;

        private void Awake()
        {
            enemyAI = GetComponent<BlazeAI>();
            hitStateBehaviour = enemyAI.hitStateBehaviour.GetComponent<BlazeAISpace.HitStateBehaviour>();
        }
        public override void OnDamage(Attack attack)
        {
            base.OnDamage(attack);

            
            if (currentHealth > 0)
            {
                for (int i = 0; i < attack.crowdControls.Count; i++)
                {
                    ApplyCrowdControl(attack.crowdControls[i]);
                }


                if (attack.crowdControls.Count == 0) // when there is no crowd control effect
                {
                    if (!isGroggy) //apply hit animation only when the enemy is not in groggy
                    {
                        hitStateBehaviour.hitDuration = attack.hitDuration;
                        hitStateBehaviour.hitAnim = "Damaged";
                        enemyAI.Hit(MainCharacterManager.Instance.gameObject);
                    }
                    
                }
                
            }

            else if (currentHealth <= 0)
            {
                enemyAI.Death();
            }
        }

        public void ApplyCrowdControl(CrowdControl crowdControl)
        {
            switch (crowdControl.crowdControlType)
            {
                case CrowdControlType.Stun:
                    ApplyGroggyForSecond(crowdControl.duration);
                    hitStateBehaviour.hitDuration = crowdControl.duration;
                    hitStateBehaviour.hitAnim = "Stunned";
                    enemyAI.Hit(MainCharacterManager.Instance.gameObject);
                    Debug.Log("stun");
                    break;

                case CrowdControlType.Airborne:
                    Debug.Log("Airborne");
                    break;

                case CrowdControlType.Ground:
                    Debug.Log("ground");
                    break;

                case CrowdControlType.ShieldBreak:
                    Debug.Log("shield break");
                    break;

            
            }
        }

    }

}
