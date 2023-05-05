using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KMK
{
    public class DamageCollider : MonoBehaviour
    {
        Collider damageCollider;
        public CrowdControl crowdControl;
        public List<Debuff> debuffs;

        [HideInInspector]
        public float damage = 30f;

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

