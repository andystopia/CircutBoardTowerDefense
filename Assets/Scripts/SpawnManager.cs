﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject virusEnemyPrefab;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(virusEnemyPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
