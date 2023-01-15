using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class DamagePlayer : MonoBehaviour
    {
        int damage = 25;
        private void OnTriggerEnter(Collider other)
        {
            CharacterStats characterStats = other.GetComponent<CharacterStats>();

            if (characterStats != null)
            {
                characterStats.TakeDamage(damage);
            }
        }
    }


}
