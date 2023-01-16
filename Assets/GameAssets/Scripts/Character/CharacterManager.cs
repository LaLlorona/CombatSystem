using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KMK.AnimationNameDefine;

public class CharacterManager : MonoBehaviour
{
    public bool isInteracting;
    public bool canDoCombo;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        canDoCombo = anim.GetBool(canDoComboHash);
    }
}
