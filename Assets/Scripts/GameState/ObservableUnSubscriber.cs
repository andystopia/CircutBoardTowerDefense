using System;
using System.Collections.Generic;

namespace GameState
{
    /// <summary>
    /// UnSubscriber for IObservables. Generic version
    /// of posted version on microsoft docs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableUnSubscriber<T> : IDisposable
    {
        private readonly ICollection<IObserver<T>> _observers;
        private readonly IObserver<T> _observer;

        public ObservableUnSubscriber(ICollection<IObserver<T>> observers, IObserver<T> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}