using System;
using GameState;
using UnityEngine;

namespace EnemyBehaviour
{
    public class EnemyStateMachine : GameStateMachine
    {
        [SerializeField] private GameStateChannel stateChannel;

        public GameStateChannel StateChannel => stateChannel;

        protected void Start()
        {
            foreach (var component in GetComponents<IObserver<GameActivityState>>())
                component.OnNext(StateChannel.CurrentState);
        }
    }
}