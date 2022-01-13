using GameState;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResumeButton : MonoBehaviour
    {
        [SerializeField] private GameStateChannel stateChannel;

        protected void OnMouseDown()
        {
            stateChannel.Broadcast(GameActivityState.Playing);
        }
    }
}