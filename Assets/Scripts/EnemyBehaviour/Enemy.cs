using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameGrid;
using TurretBehaviour;
using UnityEngine;

namespace EnemyBehaviour
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float energyDrop;
        [SerializeField] private float energyGain;
        [SerializeField] private float health;
        [SerializeField] private float healthGain;
        [SerializeField] private float armySize;
        [SerializeField] private float armySizeGain;
        [SerializeField] private float speed;
        [SerializeField] private float spawnRate;
        [SerializeField] private float damageValue;


        public List<GameObject> tilesToDisable;
        public List<GameObject> tilesToGoThrough;
        
        public float Health
        {
            get => health;
            set => health = value;
        }

        
        public float HealthGain => healthGain;
        public float EnergyGain => energyGain;

        public float ArmySize => armySize;

        public float ArmySizeGain => armySizeGain;

        public float SpawnRate => spawnRate;

        public float DamageValue => damageValue;

        public float EnergyDrop => energyDrop;

        public float Speed => speed;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void Init(IEnumerable<IEnemyPathNode> path)
        {
            GetComponent<EnemyPlayState>().Init(path);
        }
    }
}
