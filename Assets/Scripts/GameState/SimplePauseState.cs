using System;
using UnityEngine;

namespace GameState
{
    public abstract class SimplePauseState<T> : MonoBehaviour, IObserver<GameActivityState>, IGameObjectState
    {
        protected abstract IGameStateMachine StateMachine { get; }

        protected virtual void Awake()
        {
            enabled = false;
        }

        #region PlayPauseState

        public void OnStateStart()
        {
            if (this == null) return;
            enabled = true;
        }

        public void OnStateEnd()
        {
            if (this == null) return;
            enabled = false;
        }

        #endregion

        #region PauseListeners

        public void OnCompleted()
        {
            // do nothing.
        }

        public void OnError(Exception error)
        {
            // do nothing
        }

        public void OnNext(GameActivityState value)
        {
            if (value != GameActivityState.Paused) return;
            StateMachine.ActivateState(this);
        }

        #endregion
    }
}