using GameState;
using UnityEngine;

namespace TurretBehaviour
{
    public class TurretStateMachine : GameStateMachine
    {
        [SerializeField]
        private GameStateChannel stateChannel;
        public GameStateChannel StateChannel => stateChannel;
    }
}