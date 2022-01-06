using System;
using UnityEngine;

namespace ObserverPattern
{
    public enum MouseEventKind
    {
        MouseEntered,
        MouseExit,
    }
    public class MouseEventObservableMonoBehaviour : BasicObservableMonoBehaviour<MouseEventKind>
    {
        protected virtual void OnMouseEnter()
        {
            NotifyAll(MouseEventKind.MouseEntered);
        }

        protected virtual void OnMouseExit()
        {
            NotifyAll(MouseEventKind.MouseExit);
        }
    }
}