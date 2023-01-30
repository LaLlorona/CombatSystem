using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace KMK
{
    public class EnemyLocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        EnemyAnimatorManager enemyAnimatorManager;

        NavMeshAgent navmeshAgent;

        public Creature currentTarget;

        public LayerMask detectionLayer;

        public float distanceFromTarget;

        public float stoppingDistance = 0.5f;
        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
            enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
            navmeshAgent = GetComponent<NavMeshAgent>();
        }
        public void HandleDetection()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                Creature creatureStats = colliders[i].transform.GetComponent<Creature>();

                if (creatureStats != null)
                {
                    Vector3 targetDirection = creatureStats.transform.position - transform.position;

                    float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                    if (viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                    {
                        currentTarget = creatureStats;
                    }
                }
            }
        }

        public void HandleMoveToTarget()
        {
            Vector3 targetDirection = currentTarget.transform.position - transform.position;
            distanceFromTarget = Vector3.Distance(currentTarget.transform.position, transform.position);
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

            //if we are performing an action, stop our movement
            if (enemyManager.isPerformingAction)
            {
                enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                navmeshAgent.enabled = false;
            }

            else
            {
                if (distanceFromTarget > stoppingDistance)
                {
                    enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
                    navmeshAgent.enabled = false;
                }

                
            }
        }
    }

}
