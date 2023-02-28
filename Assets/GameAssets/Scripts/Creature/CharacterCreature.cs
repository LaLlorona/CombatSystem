using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace KMK
{
    public class CharacterCreature : Creature
    {
        public bool isCharacterActive = false;
        // Start is called before the first frame update
        public override void OnDamage(Attack attack)
        {
            if (isCharacterActive && canTakeDamage)
            {
                base.OnDamage(attack);
                
                
                MainCharacterManager.Instance.SetCharacterInvincible();
                MainCharacterManager.Instance.currentCharacterAnimatedController.PlayTargetAnimation("Damaged", true, 0.2f, false, false);
                UIManager.Instance.SetHPUI();
            }
        }
        
        public void SetCharacterActive()
        {
            isCharacterActive = true;
            canTakeDamage = true;
        }


        private void OnEnable()
        {
            CombatManager.Instance.onEvadeSuccess += RegenMpWithTimeAmount;
        }

        private void OnDisable()
        {
            CombatManager.Instance.onEvadeSuccess -= RegenMpWithTimeAmount;
        }

        public void RegenMpWithTimeAmount()
        {
            RegenMpWithTimeAmount(5f, 25f, 5);
        }

        public void RegenMpWithTimeAmount(float regenTime, float regenAmount, int numInterval)
        {
            if (isCharacterActive)
            {
                StartCoroutine(RegenMp(regenTime, regenAmount, numInterval)); 
            }
            
        }
        
        IEnumerator RegenMp(float regenTime, float regenAmount, int numInterval)
        {
       

            for (int i = 0; i < numInterval; i++)
            {
                ChangeMpValue(regenAmount / numInterval);
                
                // currentMp += regenAmount / numInterval;
                // currentMp = Mathf.Min(currentMp, maxMp);
                // UIManager.Instance.SetMPUI();
                yield return new WaitForSeconds(regenTime / numInterval);
            }
        }

        public void ChangeMpValue(float change)
        {
            currentMp += change;
            currentMp = Mathf.Min(currentMp, maxMp);
            currentMp = Mathf.Max(0, currentMp);
            MainCharacterManager.Instance.characterCombatHandler.characterSkillHandler.CheckSkillAvailabilityAndSetUI(0);
            UIManager.Instance.SetMPUI();
        }
    }

}
