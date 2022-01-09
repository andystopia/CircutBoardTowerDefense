namespace GameState
{
    public interface IGameStateMachine
    {
        void ActivateState(IGameObjectState state);
    }
}