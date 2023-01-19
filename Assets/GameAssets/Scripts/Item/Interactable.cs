using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KMK
{
    public class Interactable : MonoBehaviour
    {
        public float radius = 0.6f;

        public string interactableText;
        public string itemDescription;
        public Sprite itemIcon;
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        public virtual void Interact(MainCharacterManager characterManager)
        {
            Debug.Log("you interacted with object, base class");
        }

    }

}
