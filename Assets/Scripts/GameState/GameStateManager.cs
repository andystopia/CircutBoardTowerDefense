using KeyboardEventSystem;
using UnityEngine;

namespace GameState
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField] private GameStateChannel eventChannel;
        [SerializeField] private GameActivityState startingState;

        protected virtual void Start()
        {
            eventChannel.Broadcast(startingState);
        }

        protected virtual void Update()
        {
            // p or if it's already paused, escape.
            // toggle the playing/paused states.
            if (KeyMap.ActiveMap.Pause.WasPressedThisFrame() || KeyMap.ActiveMap.CancelOperationKey.WasPressedThisFrame() &&
                eventChannel.CurrentState == GameActivityState.Paused)
                eventChannel.Broadcast(eventChannel.CurrentState == GameActivityState.Playing
                    ? GameActivityState.Paused
                    : GameActivityState.Playing);
        }
    }
}