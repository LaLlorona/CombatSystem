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


        private void Update()
        {
            Debug.Log("number of enemies in the area is " + enemiesInArea.Count);
            foreach (Collider enemy in enemiesInArea)
            {
                Debug.Log(enemy.name);
            }
        }


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
            Debug.Log("coroutine is playing");

            Debug.Log("enemies are ");
            foreach (Collider enemy in enemiesInArea)
            {
                Debug.Log(enemy.name);
            }

            while (true)
            {
                foreach (Collider enemy in enemiesInArea)
                {
                    Debug.Log($"Apply Damage Coroutine, current enemies in area is {enemy.name}");

                    if (enemy != null)
                    {
                        Attack attack;
                        Debug.Log($"damage in area per tick is {damage}");
                        if (applyCCOnlyInFirstTick && enemiesAffectedByCC.Contains(enemy))
                        { // only apply debuff and damage
                            attack = new Attack(damage, null, debuffs,tickDuration);
                        }
                        else
                        {
                            enemiesAffectedByCC.Add(enemy);
                            attack = new Attack(damage, crowdControl, debuffs,tickDuration);
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
            StartCoroutine(ApplyDamageCoroutine());
        }

        private void Start()
        {
            StartDamageCoroutine();
        }
    }

}
