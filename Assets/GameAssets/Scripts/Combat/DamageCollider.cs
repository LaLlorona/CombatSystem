using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KMK
{
    public class DamageCollider : MonoBehaviour
    {
        Collider damageCollider;
        public List<CrowdControl> crowdControls;


        public float damage = 10f;

        private void Awake()
        {
            damageCollider = GetComponent<Collider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;
            
        }

        public void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }

        public void DisableDamageCollider()
        {
            damageCollider.enabled = false;
        }

     

    }
}

