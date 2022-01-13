using System.Collections.Generic;
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
        private void Start()
        {
        }

        public void Init(IEnumerable<IEnemyPathNode> path, EnergyCounter energyCounter, Motherboard motherboard)
        {
            GetComponent<EnemyPlayState>().Init(path, energyCounter, motherboard);
        }
    }
}