﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateWithinRange : MonoBehaviour
{
    public List<GameObject> tilesToDisable;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("TurnNode"))
        {
            Debug.Log("Collided!");
        }
    }

    /*
    public void OnCollision(Collision collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.CompareTag("Tile"))
        {
            bool isAvailable = true;
            foreach(GameObject ti in tilesToDisable)
            {
                if(ti == collision.gameObject)
                {
                    isAvailable = false;
                }
            }
            if (isAvailable)
            {
                tilesToDisable.Add(collision.gameObject);
                Debug.Log("Deactivate This One");
            }
        }
    }
    */

}