using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class EnemyMeleeDamageCollider : DamageCollider
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Attack attack = new Attack(damage, crowdControl, debuffs);
                CombatManager.Instance.DamageObject(collision.gameObject, attack);
            }
        }
    }

}
