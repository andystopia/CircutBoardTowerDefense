using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameGrid;
using GameState;
using UnityEngine;

namespace EnemyBehaviour
{
    public class EnemyPlayState : MonoBehaviour, IGameObjectState, IObserver<GameActivityState>
    {
        public bool isExploding;

        public GameObject EMPExplosion;
        private Enemy enemy;
        private EnergyCounter energyCounterScript;
        private Motherboard motherboardScript;
        private bool notMoving;

        private IEnumerator<IEnemyPathNode> path;

        private EnemyStateMachine stateMachine;
        private Vector3 targetedPosition;
        private readonly float yOffset = -0.5f;

        private void Awake()
        {
            enemy = GetComponent<Enemy>();
            stateMachine = GetComponent<EnemyStateMachine>();
            stateMachine.StateChannel.Subscribe(this);
            enabled = false;
        }

        // Update is called once per frame
        private void Update()
        {
            // if we have no path, wait until we can get one.
            if (path == null) return;
            // transform.position = Vector3.MoveTowards(transform.position, nextNode.transform.position, speed * Time.deltaTime);

            if (IsReachedCurrentNode())
                // if there are no more nodes to go to
                if (!AdvanceToNextNode())
                {
                    // destroy the object.
                    motherboardScript.hp -= enemy.DamageValue;
                    Destroy(gameObject);
                    return;
                }

            transform.position =
                Vector3.MoveTowards(transform.position, targetedPosition, enemy.Speed * Time.deltaTime);

            if (enemy.Health <= 0)
            {
                //chance for spawning a chip
                energyCounterScript.energy += enemy.EnergyDrop;
                if (isExploding)
                {
                    //this explodes the enemy
                    if (!notMoving)
                    {
                        var spawnExplosionEffectLoco = new Vector3(transform.position.x, transform.position.y + 2,
                            transform.position.z);
                        var spawnExplosionRotation = new Quaternion(180, 0, 0, 180);
                        Instantiate(EMPExplosion, spawnExplosionEffectLoco, spawnExplosionRotation);
                        notMoving = true;
                        StartCoroutine(DisableTimer());
                    }
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        public void Init(IEnumerable<IEnemyPathNode> path, EnergyCounter energyCounterScript,
            Motherboard motherboardScript)
        {
            this.path = path.GetEnumerator();
            this.energyCounterScript = energyCounterScript;
            this.motherboardScript = motherboardScript;

            this.path.MoveNext();
            transform.position = GridSpaceGlobalSpaceConverter.FromLocation(this.path.Current.Location, yOffset);
            AdvanceToNextNode();
        }

        private bool AdvanceToNextNode()
        {
            if (path == null) return true;
            var isMoved = path.MoveNext();
            if (isMoved && path.Current != null)
            {
                targetedPosition = GridSpaceGlobalSpaceConverter.FromLocation(path.Current.Location, yOffset);
                transform.LookAt(targetedPosition);
            }

            return isMoved;
        }

        private bool IsReachedCurrentNode()
        {
            var position = transform.position;
            return Enumerable.Range(0, 3).All(i => Math.Abs(position[i] - targetedPosition[i]) < 1e-6);
        }

        private IEnumerator DisableTimer()
        {
            yield return new WaitForSeconds(0.3f);
            DisableTurretsInRange(transform.position, 3.0f);
        }

        private void DisableTurretsInRange(Vector3 center, float radius)
        {
            var hitColliders = Physics.OverlapSphere(center, radius);

            foreach (var hitCollider in hitColliders)
                if (hitCollider.gameObject.TryGetComponent(out TileTurretBehavior behavior))
                {
                    var turret = behavior.GetTurret();
                    if (turret != null) turret.disableThisTurret();
                }

            Destroy(gameObject);
        }

        #region GamePlayingState

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

        #endregion

        #region GamePlayingStateChangeListener

        public void OnCompleted()
        {
            // do nothing.
        }

        public void OnError(Exception error)
        {
            // do nothing.
        }

        public void OnNext(GameActivityState value)
        {
            if (value != GameActivityState.Playing) return;
            stateMachine.ActivateState(this);
        }

        #endregion
    }
}