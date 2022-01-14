using UnityEngine;

namespace Channel
{
    [CreateAssetMenu(fileName = "Enemy Death Event Channel", menuName = "Channel/Enemy Death Event", order = 0)]
    public class EnemyDeathEventChannel : EventChannel<EnemyDeathEvent>
    {
        
    }
}