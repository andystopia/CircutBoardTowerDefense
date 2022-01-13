using System.Collections;
using System.Collections.Generic;
using EnemyBehaviour;
using UnityEngine;
using TMPro;

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
    [SerializeField] private EnemyPathManager pathManager;
    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < enemies.Count - 1; i++)
        //{
        // enemies[i].GetComponent<Enemy>();
        // }
        
        // for test exploder enemy.
        FindObjectOfType<Enemy>().Init(pathManager.GetActivePath().GetExtrapolator().GetMinimalRepresentation());
        callCooldownBase = callCooldown;
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
            enemySpawn.SetActive(false);
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
            enemy.Init(locationEnumerator);
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
        enemySpawn.SetActive(true);
    }
}
