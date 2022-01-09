using System;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

namespace GameState
{
    public abstract class GameMultiStateMachine : MonoBehaviour, IGameStateMachine
    {
        private List<IGameObjectState> activeStates;

        public virtual void ActivateState(IGameObjectState state)
        {
            state.OnStateStart();
            activeStates.Add(state);
        }

        public virtual void DisActivateAllStates()
        {
            foreach (var gameObjectState in activeStates)
            {
                gameObjectState.OnStateEnd();
            }

            activeStates.Clear();
        }
    }
    public abstract class GameStateMachine : MonoBehaviour, IGameStateMachine
    {
        private IGameObjectState activeState;
        
        private void Awake()
        {
            GameObjectHelper.AssertOnlyComponentOfType<IGameStateMachine>(this);
        }

        public void ActivateState(IGameObjectState state)
        {
            activeState?.OnStateEnd();
            activeState = state;
            activeState?.OnStateStart();
        }
    }
}