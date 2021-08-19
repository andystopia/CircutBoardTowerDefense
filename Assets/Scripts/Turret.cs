using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject target;

    public GameObject projectilePrefab;
    public Transform firePoint;
    public GameObject turretDisplay;
    public GameObject turretAnimdisplay;

    public Transform turretNeck;
    public float energyCost;
    public float level;
    public float maxLevel;
    public float sellAmount; // current = level * base sellAmount;
    public float upgradeCost; // current = level * base upgradeCost;
    public float damagePerShot;
    public float damageUp; //Damage increase per level
    public float rateOfFire;
    public float animStopTime;
    private float fireCooldownTime;
    public float range;
    public bool isTeslaTurret;
    public bool isLaserTurret;
    public bool isDisabled;

    public AudioClip fireSound;
    public AudioSource audioSource;

    private float rotationSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.25f);
        fireCooldownTime = 1 / rateOfFire;
        isDisabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((target != null) && (isDisabled == false))
        {
                Vector3 directionToPoint = target.transform.position - transform.position;
                Quaternion rotateToFaceTarget = Quaternion.LookRotation(directionToPoint);
                Vector3 rotation = Quaternion.Lerp(turretNeck.rotation, rotateToFaceTarget, Time.deltaTime * rotationSpeed).eulerAngles;
                turretNeck.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            

            if(fireCooldownTime <= 0)
            {
                Fire();
                fireCooldownTime = 1 / rateOfFire;
            }

            fireCooldownTime -= Time.deltaTime;

        }
    }

    void Fire()
    {
        //do animation here
        turretDisplay.SetActive(false);
        turretAnimdisplay.SetActive(true);
        if (!isLaserTurret)
        {
            audioSource.clip = fireSound;
            audioSource.Play();
            StartCoroutine(makeProjectile());
        } else
        {
            StartCoroutine(makeLaser());
        }
        
    }

    IEnumerator makeLaser()
    {
        yield return new WaitForSeconds(animStopTime);
        //make the laser thingies
        //have it damage an enemy once
        //pause movement
        Debug.Log("Make LASER NOW!");
        StartCoroutine(animStop());
    }


    IEnumerator animStop()
    {
        yield return new WaitForSeconds(animStopTime/2);
        if (isLaserTurret)
        {
            //end laser
            //resume movement
            Debug.Log("delete laser objects");
        }
        turretAnimdisplay.SetActive(false);
        turretDisplay.SetActive(true);

    }


    IEnumerator makeProjectile()
    {
        yield return new WaitForSeconds(animStopTime/2);
        GameObject projectileGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectileGO.GetComponent<Projectile>().ChaseThisEnemy(target, damagePerShot);
        StartCoroutine(animStop());
    }


    void UpdateTarget()
    {
        //if target is null, continue
        //if target not null, but out of range, but is out of range, continue
        if(target == null)
        {
            FindNewTarget();
        } else if((Vector3.Distance(transform.position, target.transform.position)) > range || isTeslaTurret)
        {
            FindNewTarget();
        }


    }

    void FindNewTarget()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (shortestDistance > distanceToEnemy)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && shortestDistance <= range)
        {
            target = closestEnemy;
        }
        else
        {
            target = null;
        }
    }

    public void disableThisTurret()
    {
        StartCoroutine(disableTurretTimer());
    }

    private IEnumerator disableTurretTimer()
    {
        yield return new WaitForSeconds(3.0f);
        isDisabled = false;
    }

}
