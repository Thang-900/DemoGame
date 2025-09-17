using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum HitSurFaceType
{
    Dirt = 0,
    Blood = 1,
}
[System.Serializable]
public class HitEffecMapper
{
    public HitSurFaceType surfacel;
    public GameObject effectPrefab;
}
public class HitEffectManager : Singleton<HitEffectManager>
{
    public HitEffecMapper[] effectMap;
    public GameObject GetEffectPrefab(HitSurFaceType surfaceType)
    {
        HitEffecMapper mapper=System.Array.Find(effectMap, x => x.surfacel == surfaceType);
        return mapper?.effectPrefab;
    }
}

