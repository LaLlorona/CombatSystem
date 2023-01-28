using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//DISABLE if using old input system
using UnityEngine.InputSystem;
using Cinemachine;

namespace KMK
{
    public class CameraManager : MonoBehaviour
    {
        [Header("reference on other objects")]
        public InputReader input;

        [Header("Camera properties")]
        public GameObject thirdPersonCamera;
        public CinemachineFreeLook thirdPersonFreeLookCamera;
        public CinemachineVirtualCamera lockOnCamera;
        public CinemachineTargetGroup lockOnTargetGroup;

        public GameObject firstPersonCamera;
        public Camera mainCamera;
        public CharacterLocomotion characterLocomotion;
        public int PRIORITY_LOW = 0;
        public int PRIORITY_HIGH = 10;

        [Space(10)]

        [Header("lock on property")]
        public float lockOnRadius = 35f;
      
        public Transform nearestLockOnTarget;
        public Transform currentLockOnTarget;
        public bool isLockon = false;

        List<CharacterManager> avaiableTargets = new List<CharacterManager>();

        

        public LayerMask thirdPersonMask;
        public LayerMask firstPersonMask;
        [Space(10)]

        public bool activeThirdPerson = true;
        public bool activeDebug = true;


        /**/
        private void OnEnable()
        {
            input.onLockOnInput += ToggleLockon;
        }

        private void OnDisable()
        {
            input.onLockOnInput -= ToggleLockon;
        }

        private void Awake()
        {
            SetCamera();
            SetDebug();
        }


        private void Update()
        {
            //debug
            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward, Color.green);

            Debug.DrawRay(mainCamera.transform.position, new Vector3(0, mainCamera.transform.eulerAngles.y, 0), Color.red);

            FindAvaiableLockOnTarget();

            //DISABLE if using old input system

            if (Keyboard.current.mKey.wasPressedThisFrame)
            {
                activeThirdPerson = !activeThirdPerson;
                SetCamera();
            }

            //DISABLE if using old input system
            if (Keyboard.current.nKey.wasPressedThisFrame)
            {
                SetDebug();
            }

            //ENABLE if using old input system

            /*

            if (Input.GetKeyDown(KeyCode.M))
            {
                activeThirdPerson = !activeThirdPerson;
                SetCamera();
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                SetDebug();
            }

            */
        }

        public void ToggleLockon()
        {
            
            isLockon = !isLockon;

            if (isLockon) //try to lock on
            {
               
                if (nearestLockOnTarget!= null)
                {
                    currentLockOnTarget = nearestLockOnTarget;
                    //add available target on the lockon target group
                    lockOnTargetGroup.AddMember(currentLockOnTarget, 1, 0);

                    //set priority of lockon camera
                    thirdPersonFreeLookCamera.Priority = PRIORITY_LOW;
                    lockOnCamera.Priority = PRIORITY_HIGH;
                }
                else // failed to find lock on target
                {
                    isLockon = false;
                }
            }
            else //release the lock on state
            {
                //set priority of lockon camera
                thirdPersonFreeLookCamera.Priority = PRIORITY_HIGH;
                lockOnCamera.Priority = PRIORITY_LOW;
                lockOnTargetGroup.RemoveMember(currentLockOnTarget);
            }
        }
        public void FindAvaiableLockOnTarget()
        {
            avaiableTargets.Clear();
            nearestLockOnTarget = null;
            float shortestDistance = Mathf.Infinity;

            Collider[] colliders = Physics.OverlapSphere(characterLocomotion.transform.position, lockOnRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                CharacterManager character = colliders[i].GetComponent<CharacterManager>();

                if (character != null)
                {
                    Vector3 lockTargetDirection = character.transform.position - characterLocomotion.transform.position;

                    float viewableAngle = Vector3.Angle(lockTargetDirection, mainCamera.transform.forward);

                    if (characterLocomotion.transform.root != character.transform.root && viewableAngle > -50 && viewableAngle < 50

                        )
                    {
                        avaiableTargets.Add(character);
                    }
                }
            }

            for (int i = 0; i < avaiableTargets.Count; i++)
            {
                Debug.Log(avaiableTargets[i].name);
                float distanceFromTarget = Vector3.SqrMagnitude(avaiableTargets[i].transform.position - characterLocomotion.transform.position);

                if (distanceFromTarget < shortestDistance)
                {
                    shortestDistance = distanceFromTarget;
                    nearestLockOnTarget = avaiableTargets[i].lockOnTransform;
                }
            }
        }
        public void HandleLockOn()
        {
       
            if (!isLockon)
            {
                return;
            }
            
            
    
           
        }

        public void SetCamera()
        {
            if (activeThirdPerson)
            {
                firstPersonCamera.SetActive(false);
                thirdPersonCamera.SetActive(true);

                mainCamera.cullingMask = thirdPersonMask;
            }
            else
            {
                firstPersonCamera.SetActive(true);
                thirdPersonCamera.SetActive(false);

                mainCamera.cullingMask = firstPersonMask;
            }
        }

        

        public void SetDebug()
        {
            characterLocomotion.debug = !characterLocomotion.debug;
        }
    }
}