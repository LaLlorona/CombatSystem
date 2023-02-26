using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class EnemyDamageCollider : DamageCollider
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Attack attack = new Attack(damage, crowdControl, debuffs);
                CombatManager.Instance.DamageObject(collision.gameObject, attack);
            }
            
            if (collision.gameObject.CompareTag("EvadeShadow"))
            {
                Debug.Log("Enemy hits the evade shadow, it will play additional effect defends on the character");
                CombatManager.Instance.OnEvadeSuccess();
            }
        }
    }

}
