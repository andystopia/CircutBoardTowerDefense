using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    private float wave;
    private float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemies.Count - 1; i++)
        {
            enemies[i].GetComponent<Enemy>().health += 100;
        }

        wave = 0;
        spawnRate = 1.0f;

        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemies[1], transform.position, transform.rotation);
        }
    }
}
