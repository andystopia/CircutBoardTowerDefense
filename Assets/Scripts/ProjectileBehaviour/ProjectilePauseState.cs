using EnemyBehaviour;
using GameState;
using UnityEngine;

namespace ProjectileBehaviour
{
    public class ProjectilePauseState : SimplePauseState<GameActivityState>
    {
        private ProjectileStateMachine stateMachine;

        protected override IGameStateMachine StateMachine => stateMachine;

        protected override void Awake()
        {
            stateMachine = GetComponent<ProjectileStateMachine>();
            stateMachine.StateChannel.Subscribe(this);
            base.Awake();
        }
    }
}