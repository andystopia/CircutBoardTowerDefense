using System;
using UnityEngine;

namespace GameState
{
    public class TestPauseState : MonoBehaviour, IGameObjectState, IObserver<GameActivityState>
    {
        private TestGameStateMachine machine;

        public void Awake()
        {
            machine = GetComponent<TestGameStateMachine>();
            enabled = false;
            machine.StateChannel.Subscribe(this);
        }


        protected virtual void Update()
        {
        }

        #region PauseListeners

        public void OnCompleted()
        {
            // do nothing.
        }

        public void OnError(Exception error)
        {
            // do nothing.
        }

        public void OnNext(GameActivityState value)
        {
            if (value != GameActivityState.Paused) return;
            machine.ActivateState(this);
        }

        #endregion

        #region PauseRecievers

        public void OnStateStart()
        {
            Debug.Log("Paused Begin...");
            enabled = true;
        }

        public void OnStateEnd()
        {
            Debug.Log("Pause End...");
            enabled = false;
        }

        #endregion
    }
}