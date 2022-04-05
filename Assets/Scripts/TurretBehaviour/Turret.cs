using UnityEngine;

namespace TurretBehaviour
{
    public class Turret : MonoBehaviour
    {
        private TurretPlayState playState;

        public float Range => GetComponent<TurretPlayState>().Range;

        public float EnergyCost => GetComponent<TurretPlayState>().EnergyCost;

        public float SellAmount => GetComponent<TurretPlayState>().SellAmount;

        protected virtual void Awake()
        {
            playState = GetComponent<TurretPlayState>();
        }

        public void Disable(float DTime)
        {
            playState.disableThisTurret(DTime);
        }
    }
}