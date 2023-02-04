using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace KMK
{
    public class CombatFocus : MonoBehaviour
    {
        [Header("targetHighlightGraphic")]
        public GameObject targetHighlightGraphics;

        [Header("Detection Length")]
        public float detectionRange = 10f;
        public float detectionAngle = 50f;


        #region private variables

        private Transform currentFocus;
        private AnimatedObjectActiveHandler targetAnimation;

        //private AnimatedObjectActiveHandler targetAnimation;
        private int currentFocusIndex = 0;

        private SphereCollider detectionTrigger;
        private Creature closestCreature = null;

        public LayerMask enemyLayer;

        #endregion


        private void Start()
        {
            targetHighlightGraphics = Instantiate(targetHighlightGraphics, transform);
            
            targetAnimation = targetHighlightGraphics.GetComponent<AnimatedObjectActiveHandler>();

        }

        void Update()
        {
            FindEnemiesWithinAngle();
            HandleTargetAnimation();
        }



        private void LateUpdate()
        {
            if (currentFocus != null)
            {
                targetHighlightGraphics.transform.position = currentFocus.position;
            }
        }

   

        void HandleTargetAnimation()
        {
            if (closestCreature != null)
            {

                if (!targetAnimation.isActive)
                {
                    targetAnimation.EnableObject(0.4f);
                }


            }

            else //there is no target
            {
                if (targetAnimation.isActive)
                {
                    targetAnimation.DisableObject(0.5f);
                }
            }
        }

        void FindEnemiesWithinAngle()
        {

            Collider[] enemyColliderInRange = Physics.OverlapSphere(transform.position, detectionRange, enemyLayer);
            float nearestAngleValue = detectionAngle;
            int nearestEnemyIndex = -1;
            for (int i = 0; i < enemyColliderInRange.Length; i++)
            {
                if (!enemyColliderInRange[i].gameObject.GetComponent<Creature>().isAlive)
                {//skip when the enemy is dead
                    continue;
                }
                Vector3 lookDirection = enemyColliderInRange[i].transform.position - transform.position;
                float viewableAngle = Vector3.Angle(lookDirection, Camera.main.transform.forward);
                if (viewableAngle < nearestAngleValue)
                {
                    nearestAngleValue = viewableAngle;
                    nearestEnemyIndex = i;
                }
            }

            if (nearestEnemyIndex == -1)
            {
                closestCreature = null;
                MainCharacterManager.Instance.targetEnemy = null;
            }
            else
            {
                closestCreature = enemyColliderInRange[nearestEnemyIndex].gameObject.GetComponent<Creature>();
                currentFocus = closestCreature.transform;
                MainCharacterManager.Instance.targetEnemy = currentFocus.gameObject;
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }

    }

}
