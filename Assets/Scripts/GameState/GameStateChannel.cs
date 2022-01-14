using Channel;
using UnityEngine;

namespace GameState
{
    [CreateAssetMenu(fileName = "Game State Channel", menuName = "Channel/Game State Channel", order = 0)]

    public class GameStateChannel : PersistentStateEventChannel<GameActivityState>
    {
    }
}