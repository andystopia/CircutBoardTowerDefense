using UnityEngine;

public interface IFocusIndicator
{
    /// <summary>
    /// Request the focus box to focus on a certain object
    /// and also have the focus box animate to a certain
    /// color.
    /// </summary>
    /// <param name="focusable"></param>
    /// <param name="targetColor"></param>
    void FocusOn(IFocusable focusable, Color targetColor);

    /// <summary>
    /// Request the focus box to focus on a certain
    /// object.
    /// </summary>
    /// <param name="focusable"> the object to focus on.</param>
    void FocusOn(IFocusable focusable);

    /// <summary>
    /// Stops focusing on a given object if it the
    /// focus is on that object.
    /// </summary>
    /// <param name="focusable"></param>
    void StopFocusOn(IFocusable focusable);
}