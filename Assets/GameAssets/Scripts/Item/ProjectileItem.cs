using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    [CreateAssetMenu(menuName = "Items/Projectile")]
    public class ProjectileItem : Item
    {
        [Header("Projectile Velocity Type")]
        public float forwardVelocity = 550;
        public float upwardVelocity = 0;
        public float mass = 0;
        public bool useGravity = false;

        [Header("Base Damage")]
        public float damage = 50;

        [Header("Item Model")]

        public GameObject projectileItem;

        
    }

}
