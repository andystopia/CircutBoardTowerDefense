using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject target;
    private float damage;
    private float speed = 20;
    public GameObject hitParticle;
    public bool isLaserProjectile;

    public int energyLeft;
    public float range;
    public List<GameObject> oldTargets;

    public void ChaseThisEnemy(GameObject targ, float damagePerShot)
    {
        target = targ;
        damage = damagePerShot;
    }

    void TargetHit()
    {
        if (energyLeft <= 0)    
        {
            Instantiate(hitParticle, target.transform.position, Quaternion.identity);
            target.GetComponent<Enemy>().health -= damage;
            Destroy(gameObject);
            return;
        } else
        {
            target.GetComponent<Enemy>().health -= damage;
            //particle
            if(target != null)  //this is just in case
            {
                oldTargets.Add(target);
            }
            
            energyLeft -= 1;
            FindNewTarget();
        }
    }
 
    void FindNewTarget()
    {
        //find new target that isn't any of the old targets
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (shortestDistance > distanceToEnemy)
            {
                foreach(GameObject oldTarget in oldTargets)
                {
                    if(enemy != oldTarget)
                    {
                        shortestDistance = distanceToEnemy;
                        closestEnemy = enemy;
                    }
                }
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

        //rotate to target
        if(target != null)
        {
            Vector3 directionToPoint = target.transform.position - transform.position;
            Quaternion rotateToFaceTarget = Quaternion.LookRotation(directionToPoint);
            transform.rotation = Quaternion.Euler(0f, rotateToFaceTarget.y, 0f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!isLaserProjectile)
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Vector3 directionToPoint = target.transform.position - transform.position;
                float goThisFarThisFrame = speed * Time.deltaTime;

                //damage the target and delete itself without going past the target
                if (directionToPoint.magnitude <= goThisFarThisFrame * 4.5)
                {
                    TargetHit();
                }
                else
                {
                    transform.LookAt(target.transform);
                    transform.Translate(directionToPoint.normalized * goThisFarThisFrame, Space.World);
                }
            }
        } else
        {

            Destroy(gameObject, 5);
        }
        
    }
}
