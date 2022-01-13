using System;
using GameState;
using UnityEngine;

namespace TurretBehaviour
{
    public class TurretStateMachine : GameStateMachine
    {
        [SerializeField] private GameStateChannel stateChannel;

        public GameStateChannel StateChannel => stateChannel;

        protected virtual void Start()
        {
            ConfigureState();
        }

        protected virtual void ConfigureState()
        {
            foreach (var component in GetComponents<IObserver<GameActivityState>>())
                component.OnNext(StateChannel.CurrentState);
        }
    }
}