using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class CharacterStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public int staminaLevel = 10;
        public float maxStamina;
        public float currentStamina;
        

        public CharacterHealthbar healthbar;
        AnimatedController animatedController;

        private void Awake()
        {
            animatedController = GetComponentInChildren<AnimatedController>();
        }
        // Start is called before the first frame update
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthbar.SetMaxHealth(maxHealth);

            maxStamina = SetMaxStaminaFromHealthLevel();
            currentStamina = maxStamina;
        }

        private float SetMaxStaminaFromHealthLevel()
        {
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthbar.SetCurrentHealth(currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animatedController.PlayTargetAnimation("Death", true, 0.2f);
            }
            else
            {
                animatedController.PlayTargetAnimation("Damaged", true, 0.2f);
            }
        }

        public void ReduceStamina(float amount)
        {
            Debug.Log($"stamina reduced with ${amount}");
            
            currentStamina -= amount;
            healthbar.SetCurrentStamina(currentStamina / maxStamina);


        }
    }

}
