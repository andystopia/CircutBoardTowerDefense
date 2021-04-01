using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    public GameObject projectilePrefab;
    public Transform firePoint;

    public Transform turretNeck;
    public float energyCost;
    public float sellAmount;
    public float damagePerShot;
    public float rateOfFire;
    private float fireCooldownTime = 0;
    public float range;

    public float rotationSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector3 directionToPoint = target.position - transform.position;
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
        GameObject projectileGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectileGO.GetComponent<Projectile>().ChaseThisEnemy(target, damagePerShot);
    }


    void UpdateTarget()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach(GameObject enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(shortestDistance > distanceToEnemy)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if(closestEnemy != null && shortestDistance <= range)
        {
            target = closestEnemy.transform;
        } else
        {
            target = null;
        }


    }
}
