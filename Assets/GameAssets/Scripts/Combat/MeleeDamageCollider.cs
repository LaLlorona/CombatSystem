using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class MeleeDamageCollider : DamageCollider
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Attack attack = new Attack(damage, crowdControls);
                CombatManager.Instance.DamageObject(collision.gameObject, attack);
            }
        }
    }
    

}
