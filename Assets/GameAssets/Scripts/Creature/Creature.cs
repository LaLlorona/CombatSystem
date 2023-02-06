using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class Creature : MonoBehaviour, IDamageable
    {
        public delegate void CreatureEvent();

        public event CreatureEvent onCreatureDeath;
        public event CreatureEvent onCreatureDamaged;

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



        [Header("CC states")]
        private IEnumerator groggyRoutine;
        public bool isGroggy;

        public bool isStunned = false;
        public bool isAirborned = false;
        public bool isGrounded = false;
        public bool isShieldBreaked = false;

        [Header("CC Timer")]
        public float shieldBreakLeftTime = 0f;
        public float shieldBreakAmount = 0f;
        

        private void Start()
        {
            if (creatureType == CreatureType.Player || creatureType == CreatureType.Player)
            {
                isAlive = true;
                canTakeDamage = true;
           
            }

            else if (creatureType == CreatureType.Boss)
            {
                isAlive = true;
                canTakeDamage = true;
        
            }

            
        }
        public virtual void OnDamage(Attack attack)
        {
            for (int i = 0; i < attack.crowdControls.Count; i++)
            {
                Debug.Log(attack.crowdControls[i]);
            }
            if (canTakeDamage)
            {
                currentHealth -= attack.damage;
                onCreatureDamaged?.Invoke();

                

            }
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isAlive = false;
                onCreatureDeath?.Invoke();
            }
        }

        IEnumerator ApplyStunRoutineForSeconds(float time)
        {
            isGroggy = true;
            yield return new WaitForSeconds(time);
            isGroggy = false;
        }
        public virtual void ApplyGroggyForSecond(float time)
        {
            if (groggyRoutine != null)
            {
                StopCoroutine(groggyRoutine);
            }
            groggyRoutine = ApplyStunRoutineForSeconds(time);
            StartCoroutine(groggyRoutine);


        }

        
    }
}

