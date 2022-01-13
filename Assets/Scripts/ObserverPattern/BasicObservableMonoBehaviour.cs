using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace ObserverPattern
{
    public abstract class BasicObservableMonoBehaviour<T> : MonoBehaviour, IObservable<T>
    {
        protected ICollection<IObserver<T>> Observers { get; } = new List<IObserver<T>>();


        /// <summary>
        ///     Subscribes to events from this observable.
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<T> observer)
        {
            Observers.Add(observer);
            return new BasicObserverUnsubscriber<T>(this, observer);
        }

        /// <summary>
        ///     You probably should just use the displose pattern
        ///     to do this, but this method will remove yourself
        ///     from the listening pool.
        /// </summary>
        /// <param name="observer"></param>
        public void Unsubscribe([NotNull] IObserver<T> observer)
        {
            Observers.Remove(observer);
        }

        protected void NotifyAll(T ev)
        {
            foreach (var observer in Observers) observer.OnNext(ev);
        }
    }

    public class BasicObserverUnsubscriber<T> : IDisposable
    {
        [NotNull] private readonly BasicObservableMonoBehaviour<T> observable;
        [NotNull] private readonly IObserver<T> observer;

        public BasicObserverUnsubscriber([NotNull] BasicObservableMonoBehaviour<T> observable,
            [NotNull] IObserver<T> observer)
        {
            this.observable = observable;
            this.observer = observer;
        }

        public void Dispose()
        {
            observable.Unsubscribe(observer);
        }
    }
}