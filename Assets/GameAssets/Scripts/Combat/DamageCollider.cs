using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KMK
{
    public class DamageCollider : MonoBehaviour
    {
        Collider damageCollider;

        public int currentWeaponDamage = 25;

        private void Awake()
        {
            damageCollider = GetComponent<Collider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;
            damageCollider.enabled = false;
        }

        public void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }

        public void DisableDamageCollider()
        {
            damageCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            //if (other.gameObject.CompareTag("Player"))
            //{
            //    CharacterStats characterStats = other.GetComponent<CharacterStats>();

            //    if (characterStats != null)
            //    {
            //        characterStats.TakeDamage(currentWeaponDamage);
            //    }
            //}

            if (other.gameObject.CompareTag("Enemy"))
            {
                EnemyStats enemyStats = other.GetComponent<EnemyStats>();

                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage);
                }
            }
        }

    }
}

