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
    }

}
