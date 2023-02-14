using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class CombatManager : Singleton<CombatManager>
    {
        public void DamageObject(GameObject objectToDamage, Attack attack)
        {
            IDamageable[] damageables = objectToDamage.gameObject.GetComponentsInChildren<IDamageable>();

            for (int i = 0; i < damageables.Length; i++ )
            {
                Debug.Log(damageables[i]);
                damageables[i].OnDamage(attack);
            }
        }

        
    }

}
