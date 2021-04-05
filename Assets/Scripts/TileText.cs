using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileText : MonoBehaviour
{
    public float destroyTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}
