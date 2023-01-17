using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KMK
{
    public class CharacterHealthbar : MonoBehaviour
    {
        public Slider hpSlider;
        public Slider staminaSlider;

        public void SetMaxHealth(int maxHealth)
        {
            hpSlider.maxValue = maxHealth;
            hpSlider.value = maxHealth;
        }
        public void SetCurrentHealth(int currentHealth)
        {
            hpSlider.value = currentHealth;
        }

   
        public void SetCurrentStamina(float currentHealthPercentage)
        {
            staminaSlider.value = currentHealthPercentage;
        }
    }
}

