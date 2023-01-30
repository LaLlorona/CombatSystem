using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class EnemyStats : Creature
    {

        Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        // Start is called before the first frame update
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;

        }

        private float SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
  

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Death");
            }
            else
            {
                animator.Play("Damaged");
            }



        }
    }

}
