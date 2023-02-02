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
        private List<Creature> nearbyEnemies;
        private List<Creature> nearbyEnemiesWithinDetectionAngle;

        private Transform currentFocus;
        private AnimatedObjectActiveHandler targetAnimation;

        //private AnimatedObjectActiveHandler targetAnimation;
        private int currentFocusIndex = 0;

        private SphereCollider detectionTrigger;
        private Creature closestCreature = null;

        #endregion


        private void Start()
        {
            targetHighlightGraphics = Instantiate(targetHighlightGraphics, transform);
            targetAnimation = targetHighlightGraphics.GetComponent<AnimatedObjectActiveHandler>();

            detectionTrigger = gameObject.AddComponent<SphereCollider>();
            detectionTrigger.isTrigger = true;
            detectionTrigger.radius = detectionRange;

            nearbyEnemies = new List<Creature>();
            nearbyEnemiesWithinDetectionAngle = new List<Creature>();

        }

        void Update()
        {
            //Debug.Log(nearbyEnemies);
            //if (nearbyEnemies.Count > 0)
            //{

            //    UpdateFocus();
            //    if (!targetAnimation.isActive)
            //    {
            //        targetAnimation.EnableObject(0.4f);
            //    }


            //}

            //else
            //{
            //    if (targetAnimation.isActive)
            //    {
            //        targetAnimation.DisableObject(0.5f);
            //    }
            //}

            FindEnemiesWithinAngle();
            if (closestCreature != null) // currently, there is a target
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

        private void LateUpdate()
        {
            if (currentFocus != null)
            {
                targetHighlightGraphics.transform.position = currentFocus.position;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Creature creatureInFocus = other.GetComponent<Creature>();

            if (creatureInFocus != null)
            {
                
                nearbyEnemies.Add(creatureInFocus);
                
            }
            //UpdateFocus();
        }

        private void OnTriggerExit(Collider other)
        {
            Creature creatureInFocus = other.GetComponent<Creature>();

            if (creatureInFocus != null)
            {
                if (nearbyEnemies.Contains(creatureInFocus))
                {
                    nearbyEnemies.Remove(creatureInFocus);
                }
            }
            //UpdateFocus();
        }

        void FindEnemiesWithinAngle()
        {
            float nearestAngleValue = detectionAngle;
            int nearestEnemyIndex = -1;
            for (int i = 0; i < nearbyEnemies.Count; i++)
            {
                Vector3 lookDirection = nearbyEnemies[i].transform.position - transform.position;
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
                currentFocus = null;
                MainCharacterManager.Instance.targetEnemy = null;
            }
            else
            {
                closestCreature = nearbyEnemies[nearestEnemyIndex];
                currentFocus = closestCreature.transform;
                MainCharacterManager.Instance.targetEnemy = currentFocus.gameObject;
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }


        //}

        //void UpdateFocus()
        //{


        //    if (nearbyEnemies.Count > 0)
        //    {
        //        FindNearestEnemy();
        //        FindAngularNearestEnemy();
        //        return;

        //    }
        //    closestCreature = null;
        //    MainCharacterManager.Instance.targetEnemy = null;
        //}

        //public void FindNearestEnemy()
        //{
        //    nearbyEnemies.RemoveAll(x => x == null);
        //    closestCreature = nearbyEnemies.OrderBy(x => Vector3.SqrMagnitude(x.transform.position - transform.position)).FirstOrDefault();
        //    currentFocus = closestCreature.transform;
        //    MainCharacterManager.Instance.targetEnemy = currentFocus.gameObject;
        //    Debug.Log($"current focus is {currentFocus.name}");
        //}

        //public void FindAngularNearestEnemy()
        //{
        //    float nearestAngleValue = Mathf.Infinity;
        //    int nearestEnemyIndex = -1;
        //    for (int i = 0; i <nearbyEnemies.Count; i++)
        //    {
        //        Vector3 lookDirection = nearbyEnemies[i].transform.position - transform.position;
        //        float viewableAngle = Vector3.Angle(lookDirection, Camera.main.transform.forward);
        //        if (viewableAngle < nearestAngleValue)
        //        {
        //            nearestAngleValue = viewableAngle;
        //            nearestEnemyIndex = i;
        //        }
        //    }

        //    if (nearestEnemyIndex == -1)
        //    {
        //        closestCreature = null;
        //        currentFocus = null;
        //        MainCharacterManager.Instance.targetEnemy = null;
        //    }
        //    else
        //    {
        //        closestCreature = nearbyEnemies[nearestEnemyIndex];
        //        currentFocus = closestCreature.transform;
        //        MainCharacterManager.Instance.targetEnemy = currentFocus.gameObject;
        //    }



        //}


    }

}
