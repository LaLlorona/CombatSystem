using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class EnemyHPBarHandler : MonoBehaviour
    {
        public Creature targetCreature;
        private const float DAMAGED_HEALTH_FADE_TIME = 0.5f;
        private const float DAMAGED_HEALTH_WAIT_TIME = 1.0f;

        public GameObject healthBar;
        public Slider hpSlider;
        public CanvasGroup healthBarTransparency;
        //public Slider hpSlider;
        public Gradient hpGradient;
        public Image fill;
        public Image damageBarImage;
        public Color damageBarColor;

        public float healthbarShowTime = 3.0f;
        public float healthbarFadeTime = 0.3f;

        private float maxHealth;
        private float currentHealth;


        private void Start()
        {
            Debug.Log(targetCreature);
            targetCreature.onCreatureDamaged += SetHPBar;
            hpSlider = healthBar.GetComponent<Slider>();
            healthBarTransparency = healthBar.GetComponent<CanvasGroup>();
            healthBarTransparency.alpha = 0.0f;

            damageBarImage.color = damageBarColor;
        }

        private void OnDestroy()
        {
            targetCreature.onCreatureDamaged -= SetHPBar;
        }

        private void SetHPBar()
        {
            maxHealth = targetCreature.maxHealth;
            currentHealth = targetCreature.currentHealth;



            hpSlider.value = currentHealth / maxHealth;
            fill.color = hpGradient.Evaluate(currentHealth / maxHealth);

            StopCoroutine("ShowHealthbarAndHide");
            StartCoroutine("ShowHealthbarAndHide");

            StopCoroutine("ShowDamageBarAndShrink");
            StartCoroutine("ShowDamageBarAndShrink");

        }

        IEnumerator ShowHealthbarAndHide()
        {
            //hpSlider.gameObject.SetActive(true);
            healthBarTransparency.alpha = 1.0f;


            yield return new WaitForSeconds(healthbarShowTime);

            int numFadeInterval = 100;
            for (int i = 0; i < numFadeInterval; i++)
            {
                healthBarTransparency.alpha -= 0.01f;
                yield return new WaitForSeconds(healthbarFadeTime / numFadeInterval);
            }


            healthBarTransparency.alpha = 0.0f;

        }

        IEnumerator ShowDamageBarAndShrink()
        {
            float currentFillAmount = damageBarImage.fillAmount;
            yield return new WaitForSeconds(DAMAGED_HEALTH_WAIT_TIME);

            float targetFillAmount = hpSlider.value;

            int numShrinkInterval = 100;
            for (int i = 0; i < numShrinkInterval; i++)
            {

                float reduceValue = (currentFillAmount - targetFillAmount) / numShrinkInterval;
                damageBarImage.fillAmount -= reduceValue;
                yield return new WaitForSeconds(DAMAGED_HEALTH_FADE_TIME / numShrinkInterval);
            }


        }

     

    }

}