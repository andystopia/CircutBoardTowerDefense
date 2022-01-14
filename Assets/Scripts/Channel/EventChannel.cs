using System;
using System.Collections.Generic;
using GameState;
using UnityEngine;

namespace Channel
{
    public class EventChannel<S> : ScriptableObject, IObservable<S>
    {
        private readonly ICollection<IObserver<S>> stateListeners = new List<IObserver<S>>();

        public virtual IDisposable Subscribe(IObserver<S> observer)
        {
            stateListeners.Add(observer);
            return new ObservableUnSubscriber<S>(stateListeners, observer);
        }

        public virtual void Broadcast(S state)
        {
            foreach (var stateListener in stateListeners) stateListener.OnNext(state);
        }

        public virtual void DisconnectAll()
        {
            foreach (var stateListener in stateListeners) stateListener.OnCompleted();

            stateListeners.Clear();
        }
    }
}