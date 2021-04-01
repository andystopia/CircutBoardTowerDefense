using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;
    private Transform target;

    private float speed = 20;

    public void ChaseThisEnemy(Transform target, float damagePerShot)
    {
        this.target = target;
        damage = damagePerShot;
    }

    void TargetHit()
    {
        target.GetComponent<Enemy>().health -= damage;
        //instantiate particle for when something is hit here? (then Destroy(particle, 3); it afterwards (use code like Fire()))
        gameObject.SetActive(false);
        Destroy(gameObject);
        return;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        } else
        {
            Vector3 directionToPoint = target.position - transform.position;
            float goThisFarThisFrame = speed * Time.deltaTime;

            //damage the target and delete itself without going past the target
            if(directionToPoint.magnitude <= goThisFarThisFrame)
            {
                TargetHit();
            }

            transform.Translate(directionToPoint.normalized * goThisFarThisFrame, Space.World);
            transform.LookAt(target.transform);

        }
    }
}
