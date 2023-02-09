using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class AreaDamageCollider : DamageCollider
    {
        public float timeBetweenDamage = 0.5f;
        private List<Collider> enemiesInArea = new List<Collider>();
        private List<Collider> enemiesAffectedByCC = new List<Collider>();

        public bool applyCCOnlyInFirstTick = true;
        public float tickDuration = 0.1f;

        private IEnumerator damageCoroutine;

        


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                enemiesInArea.Add(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                enemiesInArea.Remove(other);
            }
        }

        private IEnumerator ApplyDamageCoroutine()
        {
            

            while (true)
            {
              
                for (int i = 0; i < enemiesInArea.Count; i++)
                {
                    Collider enemy = enemiesInArea[i];
                    if (enemy != null)
                    {
        
                        Attack attack;

                        if (applyCCOnlyInFirstTick && enemiesAffectedByCC.Contains(enemy))
                        { // only apply debuff and damage
                            attack = new Attack(damage, null, debuffs, tickDuration);
                        }
                        else
                        {
                            enemiesAffectedByCC.Add(enemy);
                            attack = new Attack(damage, crowdControl, debuffs, tickDuration);
                        }

                        CombatManager.Instance.DamageObject(enemy.gameObject, attack);
                    }
                    else
                    {
                        enemiesInArea.Remove(enemy);
                    }
                }
                yield return new WaitForSeconds(timeBetweenDamage);
            
            }      
        }

        public void StartDamageCoroutine()
        {
            Debug.Log("start coroutine called");
            enemiesAffectedByCC.Clear();
            EnableDamageCollider();

            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
            }
            damageCoroutine = ApplyDamageCoroutine();
            StartCoroutine(damageCoroutine);
        }

        
    }

}
