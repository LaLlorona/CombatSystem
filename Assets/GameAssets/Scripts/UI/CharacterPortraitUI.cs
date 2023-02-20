using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPortraitUI : MonoBehaviour
{
    [Header("Character Portrait setting")]
    public Image concentricCircleImage;
    public float maxRadius = 10f;  // Maximum radius of the largest circle
    public float minRadius = -10f;   // Minimum radius of the smallest circle
    public float speed = 1000f;        // Speed at which the circles expand or contract
    public float baseDelay = 0.05f;      // Delay between each circle's expansion or contraction
    public float delayAtMaxRadius = 0.15f;
    private void OnEnable()
    {
        StartCoroutine("AnimateCircles");
    }

    private void OnDisable()
    {
        StopCoroutine("AnimateCircles");
    }

    IEnumerator AnimateCircles()
    {
        float currentRadius = minRadius;

        while (true)
        {
            if (currentRadius < maxRadius)
            {
                currentRadius += speed * Time.deltaTime;
                concentricCircleImage.rectTransform.sizeDelta = new Vector2(currentRadius * 2, currentRadius * 2);
                yield return new WaitForSeconds(baseDelay);
            }
            else
            {
                yield return new WaitForSeconds(delayAtMaxRadius);
                currentRadius = minRadius;
                
            }

        }
    }
}
