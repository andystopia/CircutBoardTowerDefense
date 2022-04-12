using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace KeyboardEventSystem
{
    [System.Serializable]
    public class MultiKey : Key
    {

        [SerializeField] private Mode mode;
        public enum Mode
        {
            Or,
            And,
        }
        [SerializeField] private SingleKey[] keys;

        public MultiKey(Mode mode, SingleKey[] keys)
        {
            this.mode = mode;
            this.keys = keys;
        }

        public override bool WasPressedThisFrame()
        {
            if (mode == Mode.Or)
            {
                return keys.Any(key => key.WasPressedThisFrame());
            }

            return keys.All(key => key.WasPressedThisFrame());
        }

        public override bool WasReleasedThisFrame()
        {
            if (mode == Mode.Or)
            {
                return keys.Any(key => key.WasReleasedThisFrame());
            }

            return keys.All(key => key.WasReleasedThisFrame());
        }

        public override bool IsPressed()
        {
            if (mode == Mode.Or)
            {
                return keys.Any(key => key.IsPressed());
            }

            return keys.All(key => key.IsPressed());
        }
    }
}