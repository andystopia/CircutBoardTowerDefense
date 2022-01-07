namespace PrimitiveFocus
{
    /// <summary>
    ///  This interface defines the contract
    /// by which behaviors which represent
    /// what an object looks like when focused
    /// behave as.
    /// </summary>
    public interface IFocusDisplay
    {
        void Show();
        void Hide();
    }
}