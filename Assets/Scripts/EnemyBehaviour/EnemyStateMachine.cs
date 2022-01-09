using System.Collections.Generic;
using GameState;
using UnityEngine;

namespace EnemyBehaviour
{
    public class EnemyStateMachine : GameStateMachine
    {
        [SerializeField]
        private GameStateChannel stateChannel;
        public GameStateChannel StateChannel => stateChannel;

        
    }
}