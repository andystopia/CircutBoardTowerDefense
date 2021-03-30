using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject virusEnemyPrefab;
    public GameObject pingEnemyPrefab;
    public GameObject trojanEnemyPrefab;
    public GameObject bossEnemyPrefab;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(virusEnemyPrefab, transform.position, transform.rotation);
        Instantiate(pingEnemyPrefab, transform.position, transform.rotation);
        Instantiate(trojanEnemyPrefab, transform.position, transform.rotation);
        Instantiate(bossEnemyPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
