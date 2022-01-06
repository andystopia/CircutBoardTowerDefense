
using ActiveOrInactiveStateManagement;
using UnityEngine;

public interface ITileFocusDisplay
{
   public void Init(FocusIndicator indicator);
   void SetFocusColor(Color focusColor);
   void Show();
   void Hide();
}