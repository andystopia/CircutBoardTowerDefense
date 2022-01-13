using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using EnemyBehaviour;
using GameGrid;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public float wave;
    public TextMeshProUGUI waveDisplayText;
    public GameObject tutorialDisplayText;
    public GameObject enemySpawn;
    public AudioClip spawnSound;
    public AudioSource audioSource;
    public float callCooldown;
    private float callCooldownBase;
    public bool isOnCd = false;
    private EnemySpawnExclusionZone exclusionZone;
    [SerializeField] private EnergyCounter energyCounter;
    [SerializeField] private Motherboard motherboard;
    [SerializeField] private EnemyPathManager pathManager;
    // Start is called before the first frame update
    

    
    public void UpdateExclusionZone()
    {
        if (exclusionZone == null) exclusionZone = GetComponent<EnemySpawnExclusionZone>();
        
        var firstEnemyPathNode = pathManager.GetActivePath().GetExtrapolator().GetMinimalRepresentation().First();
        System.Diagnostics.Debug.Assert(firstEnemyPathNode.OutgoingDirection != null, "firstEnemyPathNode.OutgoingDirection != null");
        exclusionZone.SetDirection(firstEnemyPathNode.Location, firstEnemyPathNode.OutgoingDirection.Value);    
    }
    
    void Start()
    {
        //for (int i = 0; i < enemies.Count - 1; i++)
        //{
        // enemies[i].GetComponent<Enemy>();
        // }

        
        // for test exploder enemy.
        FindObjectOfType<Enemy>().Init(pathManager.GetActivePath().GetExtrapolator().GetMinimalRepresentation(), energyCounter, motherboard);
        callCooldownBase = callCooldown;
        CalculateCorrectTransform();
    }

    public void CalculateCorrectTransform()
    {
        var firstEnemyPathNode = pathManager.GetActivePath().GetExtrapolator().GetMinimalRepresentation().First();
        gameObject.transform.position = GridSpaceGlobalSpaceConverter.FromLocation(firstEnemyPathNode.Location, 3);
        // make sure that this thing isn't null.
        System.Diagnostics.Debug.Assert(firstEnemyPathNode.OutgoingDirection != null, "firstEnemyPathNode.OutgoingDirection != null");
        gameObject.transform.rotation = Quaternion.Euler(CardinalDirectionToEuler(firstEnemyPathNode.OutgoingDirection.Value));
    }

    private Vector3 CardinalDirectionToEuler(CardinalDirection direction)
    {
        return direction switch
        {
            CardinalDirection.North => new Vector3(0, 180, 0),
            CardinalDirection.South => new Vector3(0, 0, 0),
            CardinalDirection.East => new Vector3(0, 270, 0),
            CardinalDirection.West => new Vector3(0, 90, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    // Update is called once per frame
    void Update()
    {
        waveDisplayText.text = ("Wave " + wave);

        if (Input.GetKeyDown(KeyCode.Space) && isOnCd == false)
        {
            audioSource.clip = spawnSound;
            audioSource.Play();
            wave += 1;
            PickWaveType(2);
            isOnCd = true;
            // enemySpawn.SetActive(false);
            enemySpawn.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.67f);
            StartCoroutine(Cooldown());
        }
    }

    public void PickWaveType(int enemyTypes) //enemyTypes = number of enemy types to spawn in the wave (max 5)
    {
        for (int i = 0; i < enemyTypes; i++)
        {
            int waveType = Random.Range(0, enemies.Count - 1);
            float armySize = (enemies[waveType].GetComponent<Enemy>().ArmySize) + ((enemies[waveType].GetComponent<Enemy>().ArmySizeGain) * (wave - 1));
            float spawnRate = enemies[waveType].GetComponent<Enemy>().SpawnRate;
            if (i >= 1)
            {
                StartCoroutine(SpawnWave(waveType, armySize, spawnRate + 0.5f));
            }
            else StartCoroutine(SpawnWave(waveType, armySize, spawnRate));
        }
    }

    IEnumerator SpawnWave(int enemyType, float armySize, float spawnRate)
    {
        float counter = armySize;
        while (counter > 0)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject temp = Instantiate(enemies[enemyType], transform.position, transform.rotation);
            var enemy = temp.GetComponent<Enemy>();
            enemy.Health += (temp.GetComponent<Enemy>().HealthGain) * (wave - 1);
            enemy.Health += (temp.GetComponent<Enemy>().EnergyGain) * (wave - 1);
            var locationEnumerator = pathManager.GetActivePath().GetExtrapolator().GetMinimalRepresentation();
            if (locationEnumerator == null)
            {
                Debug.Log("enumerator null in spawnwave", this);
            }
            enemy.Init(locationEnumerator, energyCounter, motherboard);
            counter -= 1;
        }
    }

    IEnumerator Cooldown()
    {
        while (callCooldown > 0)
        {
            yield return new WaitForSeconds(1);
            callCooldown -= 1;
        }
        tutorialDisplayText.SetActive(false);
        isOnCd = false;
        callCooldown = callCooldownBase;
        // enemySpawn.SetActive(true);
        enemySpawn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
}
