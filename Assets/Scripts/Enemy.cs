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

    public GameObject EMPExplosion;
    private bool notMoving = false;

    public List<GameObject> tilesToDisable;
    public List<GameObject> tilesToGoThrough;
    public bool isExploding;
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
                //this explodes the enemy
                if (!notMoving)
                {
                    Vector3 spawnExplosionEffectLoco = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
                    Quaternion spawnExplosionRotation = new Quaternion(180, 0, 0, 180);
                    Instantiate(EMPExplosion, spawnExplosionEffectLoco, spawnExplosionRotation);
                    notMoving = true;
                    StartCoroutine(disableTimer());
                }
            } else
            {
                Destroy(gameObject);
            }
            
            return;
        }

        if (transform.position.z < -9.5)
        {
            motherboardScript.hp -= damageValue;
            Destroy(gameObject);
        }
    }

    IEnumerator disableTimer()
    {
        yield return new WaitForSeconds(0.3f);
        disableTurretsInRange(transform.position, 3.0f);
    }

    void disableTurretsInRange(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Turret"))
            {
                turretScript = hitCollider.gameObject.GetComponent<Turret>();
                turretScript.disableThisTurret();
            }
        }
        Destroy(gameObject);
    }

}
