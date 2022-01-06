using ActiveOrInactiveStateManagement;
using UnityEngine;

public interface IFocusable : IActiveOrInactiveState
{
    Bounds FocusBounds { get; }
}