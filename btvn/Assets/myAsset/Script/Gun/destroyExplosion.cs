using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    public int liftime = 5;
    void Start()
    {
        Destroy(gameObject, liftime);
    }

}
