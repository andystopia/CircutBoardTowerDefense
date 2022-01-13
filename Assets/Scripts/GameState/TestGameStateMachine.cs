using UnityEngine;

namespace GameState
{
    public class TestGameStateMachine : GameStateMachine
    {
        [SerializeField] private GameStateChannel stateChannel;

        public GameStateChannel StateChannel => stateChannel;
    }
}