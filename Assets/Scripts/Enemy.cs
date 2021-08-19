using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject nextNode;
    private Motherboard motherboardScript;
    private EnergyCounter energyCounterScript;
    private GameManager gameManagerScript;
    public float energyDrop;
    public float energyGain;
    public float health;
    public float healthGain;
    public float armySize;
    public float armySizeGain;
    public float speed;
    public float spawnRate;
    public float damageValue;

    public List<GameObject> tilesToDisable;
    public List<GameObject> tilesToGoThrough;
    public bool isExploding;
    public GameObject deactivator;
    public Turret turretScript;
    
    // Start is called before the first frame update
    void Start()
    {
        energyCounterScript = GameObject.Find("Energy Counter").GetComponent<EnergyCounter>();
        motherboardScript = GameObject.Find("Motherboard").GetComponent<Motherboard>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, nextNode.transform.position, speed * Time.deltaTime);
        if (health <= 0)
        {
            //chance for spawning a chip
            energyCounterScript.energy += energyDrop;
            if (isExploding)
            {
                //particle effect
                explodeEnemy(transform.position, 5.0f);
            }
            Destroy(gameObject);
            return;
        }

        if (transform.position.z < -9.5)
        {
            motherboardScript.hp -= damageValue;
            Destroy(gameObject);
        }
    }


    void explodeEnemy(Vector3 center, float radius)
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Turret"))
            {
                Debug.Log("Disabled!");
                turretScript = hitCollider.gameObject.GetComponent<Turret>();
                turretScript.isDisabled = true;
            }
        }

    }

     
 }
