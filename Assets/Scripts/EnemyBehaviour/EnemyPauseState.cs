using GameState;

namespace EnemyBehaviour
{
    public class EnemyPauseState : SimplePauseState<GameActivityState>
    {
        private EnemyStateMachine stateMachine;

        protected override IGameStateMachine StateMachine => stateMachine;

        protected override void Awake()
        {
            stateMachine = GetComponent<EnemyStateMachine>();
            stateMachine.StateChannel.Subscribe(this);
            base.Awake();
        }
    }
}