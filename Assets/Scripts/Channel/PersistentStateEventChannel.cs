namespace Channel
{
    public class PersistentStateEventChannel<S> : EventChannel<S>
    {
        public S CurrentState { get; private set; }

        public override void Broadcast(S state)
        {
            CurrentState = state;
            base.Broadcast(state);
        }
    }
}