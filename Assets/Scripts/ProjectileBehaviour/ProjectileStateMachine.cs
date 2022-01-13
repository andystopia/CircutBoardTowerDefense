using System;
using GameState;
using JetBrains.Annotations;
using UnityEngine;

namespace ProjectileBehaviour
{
    public class ProjectileStateMachine : GameStateMachine
    {
        [SerializeField] [NotNull] private GameStateChannel stateChannel;
        public GameStateChannel StateChannel => stateChannel;

        protected void Start()
        {
            foreach (var component in GetComponents<IObserver<GameActivityState>>())
                component.OnNext(StateChannel.CurrentState);
        }
    }
}