using UnityEngine;

public interface IFloatingUIComponent
{
    void Show();
    void Hide();
    Vector3 GetDestinationPosition();
    Vector3 GetStartingPosition();
    Vector3 GetCurrentPosition();
    
}