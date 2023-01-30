using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class Creature : MonoBehaviour, IDamageable
    {
        public int healthLevel = 10;
        public float maxHealth;
        public float currentHealth;

        public int staminaLevel = 10;
        public float maxStamina;
        public float currentStamina;

        [Header("CreatureStatus")]
        public CreatureType creatureType;

        public bool isAlive = true;
        public bool canTakeDamage = true;
        public bool canBeAirborned = true;
        public bool canBeGrounded = true;
        public bool canBeShieldBreaked = true;

        private void Start()
        {
            if (creatureType == CreatureType.Player || creatureType == CreatureType.Player)
            {
                isAlive = true;
                canTakeDamage = true;
                canBeAirborned = true;
                canBeGrounded = true;
                canBeShieldBreaked = true;
            }

            else if (creatureType == CreatureType.Boss)
            {
                isAlive = true;
                canTakeDamage = true;
                canBeAirborned = false;
                canBeGrounded = true;
                canBeShieldBreaked = true;
            }
        }
        public void OnDamage(Attack attack)
        {
            if (canTakeDamage)
            {
                currentHealth -= attack.damage;

                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                }

                if (currentHealth <= 0 || isAlive)
                {
                    isAlive = false;
                    
                }
            }
        }
    }
}

