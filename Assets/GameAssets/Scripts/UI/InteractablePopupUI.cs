using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KMK
{
    public class InteractablePopupUI : MonoBehaviour
    {
        public TextMeshProUGUI interactableText;

        public void SetInteractableText(string text)
        {
            interactableText.text = text;
        }
    }
}

