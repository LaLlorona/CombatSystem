using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class CharacterStats : CreatureStats { 
        
        

        public CharacterHealthbar healthbar;
        MainCharacterManager mainCharacterManager;


        private void Awake()
        {
            mainCharacterManager = GetComponent<MainCharacterManager>();
         
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
                mainCharacterManager.currentCharacterAnimatedController.PlayTargetAnimation("Death", true, 0.2f);
            }
            else
            {
                mainCharacterManager.currentCharacterAnimatedController.PlayTargetAnimation("Damaged", true, 0.2f, false);
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
