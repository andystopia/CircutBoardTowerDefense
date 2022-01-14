using EnemyBehaviour;

namespace Channel
{
    public class EnemyDeathEvent
    {
        public EnemyDeathEvent(Enemy enemy)
        {
            Enemy = enemy;
        }

        public Enemy Enemy { get; }
    }
}