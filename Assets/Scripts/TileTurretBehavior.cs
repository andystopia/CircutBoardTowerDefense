
using UnityEngine;

public class TileTurretBehavior : MonoBehaviour, ITileTurretBehavior
{
    [SerializeField] private Turret turret;

    public Turret GetTurret()
    {
        return turret;
    }

    public void SetTurret(Turret turret)
    {
        this.turret = turret;
    }
}