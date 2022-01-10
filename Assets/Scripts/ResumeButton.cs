using GameState;
using UnityEngine;
using UnityEngine.SceneManagement;

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