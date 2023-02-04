using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KMK
{
    public class EnemyManager : CharacterManager
    {
        EnemyLocomotionManager enemyLocomotionManager;
        public bool isPerformingAction;


        [Header("AI setting")]
        public float detectionRadius = 20f;
        public float maximumDetectionAngle = 50f;
        public float minimumDetectionAngle = -50f;

        private void Awake()
        {
     
        }

        private void Update()
        {
         
        }

        
    }

}
