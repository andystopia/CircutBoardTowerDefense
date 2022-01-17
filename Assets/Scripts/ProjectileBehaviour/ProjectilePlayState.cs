using System;
using System.Collections.Generic;
using EnemyBehaviour;
using GameState;
using UnityEngine;

namespace ProjectileBehaviour
{
    public class ProjectilePlayState : MonoBehaviour, IGameObjectState, IObserver<GameActivityState>
    {
        public GameObject hitParticle;
        public bool isLaserProjectile;

        public int energyLeft;
        public float range;
        public List<GameObject> oldTargets;
        public float damage;
        private readonly float speed = 20;
        private ProjectileStateMachine stateMachine;
        private GameObject target;

        protected virtual void Awake()
        {
            stateMachine = GetComponent<ProjectileStateMachine>();
            stateMachine.StateChannel.Subscribe(this);
            enabled = false;
        }


        // Update is called once per frame
        private void Update()
        {
            if (!isLaserProjectile)
            {
                if (target == null)
                {
                    Destroy(gameObject);
                    return;
                }

                var directionToPoint = target.transform.position - transform.position;
                var goThisFarThisFrame = speed * Time.deltaTime;

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
            else
            {
                Destroy(gameObject, 1.5f);
            }
        }

        public void OnStateStart()
        {
            if (this == null) return;
            enabled = true;
        }

        public void OnStateEnd()
        {
            if (this == null) return;
            enabled = false;
        }

        public void OnCompleted()
        {
            // do nothing.
        }

        public void OnError(Exception error)
        {
            // do nothing
        }

        public void OnNext(GameActivityState value)
        {
            if (value != GameActivityState.Playing) return;
            stateMachine.ActivateState(this);
        }

        public void ChaseThisEnemy(GameObject targ, float damagePerShot)
        {
            target = targ;
            damage = damagePerShot;
        }

        private void TargetHit()
        {
            if (energyLeft <= 0)
            {
                Instantiate(hitParticle, target.transform.position, Quaternion.identity);
                target.GetComponent<Enemy>().Health -= damage;
                Destroy(gameObject);
                return;
            }

            target.GetComponent<Enemy>().Health -= damage;
            //particle
            if (target != null) //this is just in case
                oldTargets.Add(target);

            energyLeft -= 1;
            FindNewTarget();
        }

        private void FindNewTarget()
        {
            //find new target that isn't any of the old targets
            var allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            var shortestDistance = Mathf.Infinity;
            GameObject closestEnemy = null;

            foreach (var enemy in allEnemies)
            {
                var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (shortestDistance > distanceToEnemy)
                    foreach (var oldTarget in oldTargets)
                        if (enemy != oldTarget)
                        {
                            shortestDistance = distanceToEnemy;
                            closestEnemy = enemy;
                        }
            }

            if (closestEnemy != null && shortestDistance <= range)
                target = closestEnemy;
            else
                target = null;

            //rotate to target
            if (target != null)
            {
                var directionToPoint = target.transform.position - transform.position;
                var rotateToFaceTarget = Quaternion.LookRotation(directionToPoint);
                transform.rotation = Quaternion.Euler(0f, rotateToFaceTarget.y, 0f);
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if (isLaserProjectile)
            {
                Debug.Log("Hit!");
                if (collider.CompareTag("Enemy") == true)
                {
                    var temp = collider.gameObject.GetComponent<Enemy>();
                    temp.Health -= damage;
                    
                }
            }
        }
    }
}