using UnityEngine;

namespace TurretShopEntry
{
    public interface IFocusDisplay
    {
        void Show();
        void Hide();
        void SetFocusCenter(Vector3 location);
        Vector3 GetOriginalFocusCenter();
    }
}