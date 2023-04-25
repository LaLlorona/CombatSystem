using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using KMK;
using UnityEngine;

public class PlayerCameraManager : Singleton<PlayerCameraManager>
{
    private IEnumerator cameraShakeRoutine;
    private IEnumerator cameraEventRoutine;

    public CinemachineFreeLook playerCamera;
    

    CinemachineBasicMultiChannelPerlin topRigPerlin;
    CinemachineBasicMultiChannelPerlin midRigPerlin;
    CinemachineBasicMultiChannelPerlin botRigPerlin;
    

    private void Start()
    {
        topRigPerlin = playerCamera.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        midRigPerlin = playerCamera.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        botRigPerlin = playerCamera.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();


        // MainCharacterManager.Instance.currentCharacterAnimationEventHandler.onAttackOpen += DoPlayerCamShake;




    }

    private void OnDestroy()
    {
        // MainCharacterManager.Instance.currentCharacterAnimationEventHandler.onAttackOpen -= DoPlayerCamShake;
    }



    public struct CameraShake
    {
        public float strength;
        public float duration;

        public CameraShake(float str, float dur)
        {
            strength = str;
            duration = dur;
        }
    }

    

    public void PlayerCamNoise(float strength)
    {
        topRigPerlin.m_AmplitudeGain = strength;
        midRigPerlin.m_AmplitudeGain = strength;
        botRigPerlin.m_AmplitudeGain = strength;
    }

    

    IEnumerator ShakePlayerCamera(CameraShake shake)
    {
        PlayerCamNoise(shake.strength);
        yield return new WaitForSeconds(shake.duration);
        PlayerCamNoise(0);

        
    }

    public void DoPlayerCamShake()
    {
        Debug.Log("do player cam shake!!!");
        float strength = Random.Range(1.1f, 1.3f);
        float duration = Random.Range(0.3f, 0.35f);
        DoPlayerCamShake(new CameraShake(strength, duration));
    }

    public void DoPlayerCamShake(CameraShake shake)
    {
        if (cameraShakeRoutine != null)
        {
            StopCoroutine(cameraShakeRoutine);
        }
        cameraShakeRoutine = ShakePlayerCamera(shake);
        StartCoroutine(cameraShakeRoutine);
    }
}
