using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameState
{
    public class StateChannel<S> : ScriptableObject, IObservable<S>
    {
        private readonly ICollection<IObserver<S>> stateListeners = new List<IObserver<S>>();
        
        public virtual IDisposable Subscribe(IObserver<S> observer)
        {
            stateListeners.Add(observer);
            return new ObservableUnSubscriber<S>(stateListeners, observer);
        }

        public virtual void Broadcast(S state)
        {
            foreach (var stateListener in stateListeners)
            {
                stateListener.OnNext(state);
            }
        }

        public virtual void DisconnectAll()
        {
            foreach (var stateListener in stateListeners)
            {
                stateListener.OnCompleted();
            }

            stateListeners.Clear();
        }
    }
    [CreateAssetMenu(fileName = "Game State Channel", menuName = "Channels/Game State Channel", order = 0)]
    public class GameStateChannel : StateChannel<GameActivityState>
    {
        public GameActivityState CurrentState => currentState;
        private GameActivityState currentState;
        
        
        
        public override void Broadcast(GameActivityState state)
        {
            currentState = state;
            base.Broadcast(state);
        }
    }
}
