
using TurretBehaviour;
using UnityEngine;

public class TileTurretBehavior : MonoBehaviour, ITileTurretBehavior
{
    [SerializeField] private TurretPlayState turret;

    public TurretPlayState GetTurret()
    {
        return turret;
    }

    public void SetTurret(TurretPlayState turret)
    {
        this.turret = turret;
    }
}