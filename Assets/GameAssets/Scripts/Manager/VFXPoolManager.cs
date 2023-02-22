using System.Collections;
using System.Collections.Generic;
using KMK;
using UnityEngine;

using Redcode.Pools;

public class VFXPoolManager : Singleton<VFXPoolManager>
{
    PoolManager poolManager;

    public override void Awake()
    {
        base.Awake();
        poolManager = GetComponent<PoolManager>();
    }
    
    public void PlayVFX(Transform vfxTransform, string vfxName)
    {
        EffectPoolSetter vfx = poolManager.GetFromPool<EffectPoolSetter>(vfxName);
        vfx.transform.position = vfxTransform.position;
        vfx.transform.rotation = vfxTransform.rotation;

    }

    public void RemoveVFX(EffectPoolSetter clone)
    {
        poolManager.TakeToPool<EffectPoolSetter>(clone.effectName, clone);
    }
}
