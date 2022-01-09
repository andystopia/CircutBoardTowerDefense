using UnityEngine;

namespace TurretBehaviour
{
    public class Turret : MonoBehaviour
    {
        private TurretPlayState playState;

        protected virtual void Awake()
        {
            playState = GetComponent<TurretPlayState>();
        }

        public float Range => GetComponent<TurretPlayState>().Range;

        public float EnergyCost => GetComponent<TurretPlayState>().EnergyCost;

        public void disableThisTurret()
        {
            playState.disableThisTurret();
        }
    }
}