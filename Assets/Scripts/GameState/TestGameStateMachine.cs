using Newtonsoft.Json;
using UnityEditor.VersionControl;
using UnityEngine;

namespace GameState
{
    public class TestGameStateMachine : GameStateMachine
    {
        [SerializeField]
        private GameStateChannel stateChannel;
        public GameStateChannel StateChannel => stateChannel;

        

    }
}