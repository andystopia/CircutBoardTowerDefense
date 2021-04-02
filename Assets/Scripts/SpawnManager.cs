using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public float healthGain;
    public float wave;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < enemies.Count - 1; i++)
        //{
        // enemies[i].GetComponent<Enemy>();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PickWaveType();
        }
    }

    public void PickWaveType()
    {
        int waveType = Random.Range(0, enemies.Count - 1);
        float armySize = enemies[waveType].GetComponent<Enemy>().armySize;
        float spawnRate = enemies[waveType].GetComponent<Enemy>().spawnRate;
        StartCoroutine(SpawnWave(waveType, armySize, spawnRate));
    }

    IEnumerator SpawnWave(int enemyType, float armySize, float spawnRate)
    {
        float counter = armySize;
        while (counter > 0)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject temp = Instantiate(enemies[enemyType], transform.position, transform.rotation);
            temp.GetComponent<Enemy>().health += healthGain;
            counter -= 1;
        }
    }
}
