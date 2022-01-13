using GameState;

namespace TurretBehaviour
{
    public class TurretPauseState : SimplePauseState<GameActivityState>
    {
        private TurretStateMachine stateMachine;
        protected override IGameStateMachine StateMachine => stateMachine;


        protected override void Awake()
        {
            stateMachine = GetComponent<TurretStateMachine>();
            stateMachine.StateChannel.Subscribe(this);
            base.Awake();
        }
    }
}