using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public float healthGain;
    public float wave;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < enemies.Count - 1; i++)
        //{
            
        //}

        healthGain = 100;
        StartCoroutine(SpawnWave(10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWave(int armySize)
    {
        int counter = armySize;
        while (counter > 0)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject temp = Instantiate(enemies[1], transform.position, transform.rotation);
            temp.GetComponent<Enemy>().health += healthGain;
            counter -= 1;
        }
    }
}
