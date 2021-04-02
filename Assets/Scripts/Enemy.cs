using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject nextNode;
    public float energyDrop;
    public float energyGain;
    public float health;
    public float healthGain;
    public float armySize;
    public float armySizeGain;
    public float speed;
    public float spawnRate; //maybe have a multiplier for new waves?



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextNode.transform.position, speed * Time.deltaTime);
        if(health <= 0)
        {
            //chance for spawning a chip
            //ALWAYS spawn a certain amount of energy
            Destroy(gameObject);
            return;
        }
    }
}
