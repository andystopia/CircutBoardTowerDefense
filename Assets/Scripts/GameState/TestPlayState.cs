using System;
using UnityEngine;

namespace GameState
{
    public class TestPlayState : MonoBehaviour, IGameObjectState, IObserver<GameActivityState>
    {
        private TestGameStateMachine machine;

        protected virtual void Awake()
        {
            machine = GetComponent<TestGameStateMachine>();
            enabled = false;
            machine.StateChannel.Subscribe(this);
        }

        protected virtual void Update()
        {
            if (Time.frameCount % 100 == 0)
            {
                Debug.Log("Playing Game.");
            }
        }

        #region PlayPauseRegion
        public void OnCompleted()
        {
            // do nothing.
        }

        public void OnError(Exception error)
        {
            // do not handle errors
        }

        public void OnNext(GameActivityState value)
        {
            if (value != GameActivityState.Playing) return;
            machine.ActivateState(this);
        }

        #endregion

        /// <summary>
        /// This region is for the event
        /// functions that are generated when
        /// we have events that occur.
        /// </summary>
        #region StateBehavior
        public virtual void OnStateStart()
        {
            Debug.Log("Play Mode started.");
            enabled = true;
        }

        public virtual void OnStateEnd()
        {
            Debug.Log("Play Mode ended.");
            enabled = false;
        }
        #endregion
    }
}