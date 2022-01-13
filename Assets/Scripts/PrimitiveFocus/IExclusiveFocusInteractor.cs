namespace PrimitiveFocus
{
    public interface IExclusiveFocusInteractor : IFocusInteractor
    {
        void SetManager(ExclusiveSubsectionFocusManager manager);

        /// <summary>
        ///     The more specific form if you have access to an instance of this class.
        /// </summary>
        /// <returns></returns>
        ExclusiveSubsectionFocusManager GetFocusManager();
    }
}