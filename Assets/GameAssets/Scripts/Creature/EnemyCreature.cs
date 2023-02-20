using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    
    public class EnemyCreature : Creature
    {
        public BlazeAI enemyAI;
        
        BlazeAISpace.HitStateBehaviour hitStateBehaviour;
        

        public override void Awake()
        {
            base.Awake();
            enemyAI = GetComponent<BlazeAI>();
            hitStateBehaviour = enemyAI.hitStateBehaviour.GetComponent<BlazeAISpace.HitStateBehaviour>();
        }
        public override void OnDamage(Attack attack)
        {

            base.OnDamage(attack);

            ApplyCrowdControl(attack.crowdControl);

            for (int i = 0; i < attack.debuffs.Count; i++)
            {
                ApplyDebuff(attack.debuffs[i]);
            }

            if (currentHealth > 0)
            {
                


                if (attack.crowdControl == null) // when there is no crowd control effect
                {
                    if (!isGroggy) //apply hit animation only when the enemy is not in groggy
                    {
                        if (attack.hitDuration >= 0.25f)
                        {
                            ChangeToHitState(attack.hitDuration, "Damaged");
                        }
               
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
            if (crowdControl == null)
            {
                return;
            }
            else
            {
                MainCharacterManager.Instance.characterCombatHandler.AddAttackAdditionalEffectChecker(crowdControl);
                switch (crowdControl.crowdControlType)
                {
                    case CrowdControlType.Stun:
                        ApplyGroggyForSecond(crowdControl.duration);
                        ChangeToHitState(crowdControl.duration, "Stunned");
                        Debug.Log("stun");
                        break;

                    case CrowdControlType.Airborne:
                        ApplyGroggyForSecond(crowdControl.duration);
                        ChangeToHitState(crowdControl.duration, "Airborne");
                        break;

                    case CrowdControlType.Ground:
                        Debug.Log("ground");
                        break;
                }
            }
            
        }
        public void ApplyDebuff(Debuff debuff)
        {
            if (debuff == null)
            {
                return;
            }
            else
            {
                MainCharacterManager.Instance.characterCombatHandler.AddAttackAdditionalEffectChecker(debuff);
                Debug.Log($"debuff type is {debuff.debuffType} and duration is {debuff.duration}");
                CreatureVFXManager.Instance.PlayDebuffVfx(debuff, gameObject.transform);
                switch (debuff.debuffType)
                {

                    case DebuffType.ShieldBreak:
                        if (shieldBreakTimer < debuff.duration)
                        {
                            shieldBreakTimer = debuff.duration;
                            defense = (int)(creatureBaseStat.defense * debuff.debuffAmount / 100);
                        }
                        Debug.Log("shieldBreak");
                        break;
                    case DebuffType.Slow:
                        Debug.Log("slow");
                        break;
                }
            }
           
        }

        public void ChangeToHitState(float duration, string animation)
        {
            hitStateBehaviour.hitDuration = duration;
            hitStateBehaviour.hitAnim = animation;
            enemyAI.Hit(MainCharacterManager.Instance.gameObject);
        }

    }

}
