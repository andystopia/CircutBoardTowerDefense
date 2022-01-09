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

        private void Start()
        {
            stateChannel.Broadcast(GameActivityState.Playing);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                stateChannel.Broadcast(stateChannel.CurrentState == GameActivityState.Playing
                    ? GameActivityState.Paused
                    : GameActivityState.Playing);
            }
        }
    }
}