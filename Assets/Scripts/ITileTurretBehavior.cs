
using TurretBehaviour;
using UnityEngine;

public interface ITileTurretBehavior
{
    public TurretPlayState GetTurret();
    public void SetTurret(TurretPlayState turret);
}