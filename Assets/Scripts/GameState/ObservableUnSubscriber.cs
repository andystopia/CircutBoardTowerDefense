using System;
using System.Collections.Generic;

namespace GameState
{
    /// <summary>
    ///     UnSubscriber for IObservables. Generic version
    ///     of posted version on microsoft docs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableUnSubscriber<T> : IDisposable
    {
        private readonly IObserver<T> _observer;
        private readonly ICollection<IObserver<T>> _observers;

        public ObservableUnSubscriber(ICollection<IObserver<T>> observers, IObserver<T> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}