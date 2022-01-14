using EnemyBehaviour;

namespace Channel
{
    public class EnemyInvasionEvent
    {
        public EnemyInvasionEvent(Enemy enemy)
        {
            Enemy = enemy;
        }

        public Enemy Enemy { get; }
    }
}