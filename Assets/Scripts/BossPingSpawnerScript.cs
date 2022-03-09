using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPingSpawnerScript : MonoBehaviour
{
    private float spawnDelay;
    private float spawnRate;
    [SerializeField] private GameObject display;
    //[SerializeField] private float t;     //this keeps track of which wave it is

    public float pingsToSpawn;      //this needs to be determined by the wave number

    [SerializeField] private GameObject pingPrefab;

    private void Start()
    {
        spawnDelay = 4f;
        spawnRate = 0.5f;
        pingsToSpawn = 5;   //FOR NOW (not later once the constructor does this)
    }

    private void Update()
    {
        if(spawnDelay > 0)
        {
            spawnDelay -= Time.deltaTime;
            spawnDelay = spawnRate;
            spawnPing();
        }
    }

    private void spawnPing()
    {
        var enemy = Instantiate(pingPrefab);

        // determine how much heath that enemy gets. (depending on wave, which I need to determine)             //OR MAKE THEM VERY WEAK AND SMALLER!!!
        //enemy.Health += enemy.HealthGain * (wave - 1);
        //enemy.Health += enemy.EnergyGain * (wave - 1);

        // makes sure the enemy spawns
        //enemy.Init(enemyPathNodes, deathEventChannel, invasionEventChannel);
        pingsToSpawn--;
        if(pingsToSpawn < 16)
        {
            display.transform.localScale = new Vector3((pingsToSpawn + 1)/ 2, (pingsToSpawn + 1) / 2, (pingsToSpawn + 1) / 2);  //make sure this works
        }
        if(pingsToSpawn <= 0)
        {
            Destroy(gameObject);
        }
    }

}
