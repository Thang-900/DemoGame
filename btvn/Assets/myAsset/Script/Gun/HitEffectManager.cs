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
public class HitEffectManager : MonoBehaviour
{
    public HitEffecMapper[] effectMap;
}

