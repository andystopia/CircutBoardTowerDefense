
using UnityEngine;

public interface ITurretShopEntryFocusDisplay
{
    void Show();
    void Hide();
    void SetFocusCenter(Vector3 location);
    Vector3 GetOriginalFocusCenter();
}