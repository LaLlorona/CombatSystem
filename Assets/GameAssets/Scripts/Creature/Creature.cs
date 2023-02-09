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

   

        //public int healthLevel = 10;
        //public float maxHealth;
        public float currentHealth;

        //public int staminaLevel = 10;
        //public float maxStamina;
        //public float currentStamina;

        [Header ("Creature Stat")]
        public CreatureBaseStat creatureBaseStat;
        public int maxHealth;
        public int strength;
        public int defense;
        public int maxMana;


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
        public float shieldBreakTimer = 0f;
        public float shieldBreakAmount = 0f;

        public virtual void Awake()
        {
            SetCharacterStat();
        }

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
            
            if (canTakeDamage)
            {
                Debug.Log($"attack damage is {attack.damage} and defense is {defense}, final damage is {attack.damage - defense}");
                currentHealth -= Mathf.Max(0f, (attack.damage - defense));
                onCreatureDamaged?.Invoke();

                

            }
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isAlive = false;
                onCreatureDeath?.Invoke();
            }
        }

        IEnumerator ApplyGroggyRoutineForSeconds(float time)
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
            groggyRoutine = ApplyGroggyRoutineForSeconds(time);
            StartCoroutine(groggyRoutine);


        }
        private void SetCharacterStat()
        {
            maxHealth = creatureBaseStat.maxHealth;
            currentHealth = maxHealth;
            strength = creatureBaseStat.strength;
            defense = creatureBaseStat.defense;
            maxMana = creatureBaseStat.maxMana;
        }

        private void Update()
        {
            CheckDebuffTimer();
        }

        private void CheckDebuffTimer()
        {
            if (shieldBreakTimer > 0)
            {
                shieldBreakTimer -= Time.deltaTime;
            }

            if (shieldBreakTimer <=0)
            {
                defense = creatureBaseStat.defense;
            }
        }


    }
}

