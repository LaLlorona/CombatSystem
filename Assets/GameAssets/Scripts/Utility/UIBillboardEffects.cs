using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboardEffects : MonoBehaviour
{
    public bool animate;

    
    public float hoverScale = 0.2f;

    
    public float hoverSpeed = 3f;

    private Vector3 originPosition;

    private Camera mainCam;

    private void Start()
    {
        originPosition = transform.localPosition;
        mainCam = Camera.main;

    }

    private void LateUpdate()
    {
        transform.rotation = mainCam.transform.rotation;

        if (animate)
        {
            float hoverDistance = Mathf.Sin(Time.time * hoverSpeed) * hoverScale;
            transform.localPosition = originPosition + new Vector3(0f, hoverDistance, 0f);
        }
    }
}
