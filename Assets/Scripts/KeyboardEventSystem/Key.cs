namespace KeyboardEventSystem
{
    /// <summary>
    /// For maximum flexibility
    /// of API's they should do their
    /// best to take just this abstract
    /// key instance whenever they can.
    /// This design decision will hopefully
    /// seamless type system changes in the
    /// KeyMapping class with major
    /// refactorings.
    /// </summary>
    public abstract class Key
    {
        /// <summary>
        /// Determines if a key is held down.
        /// </summary>
        /// <returns>true if the key is held down, false otherwise</returns>
        public abstract bool IsPressed();

        /// <summary>
        /// Determines if this key was pressed this frame.
        /// </summary>
        /// <returns>true if the key was released this frame, false otherwise</returns>
        public abstract bool WasPressedThisFrame();

        /// <summary>
        /// Determines if the key was released this frame.
        /// </summary>
        /// <returns>true if the key was released this frame, false otherwise</returns>
        public abstract bool WasReleasedThisFrame();
    }
}