using UnityEngine;

namespace Channel
{
    [CreateAssetMenu(fileName = "Enemy Invasion Event Channel", menuName = "Channel/Enemy Invasion Event Channel", order = 0)]
    public class EnemyInvasionEventChannel : EventChannel<EnemyInvasionEvent>
    {

    }
}