using System;
using UnityEngine;
using UnityEngine.UI;

namespace KeyboardEventSystem
{
    [System.Serializable]
    public class DirectionalKeyDPad
    {
        private class KeyUnifier : Key
        {
            public enum Mode
            {
                Or,
                And,
            }
            private readonly Key a;
            private readonly Key b;
            private readonly Mode mode;

            public KeyUnifier(Key a, Key b, Mode mode = Mode.Or)
            {
                this.a = a;
                this.b = b;
                this.mode = mode;
            }

            public override bool IsPressed()
            {
                return mode switch
                {
                    Mode.Or => a.IsPressed() || b.IsPressed(),
                    Mode.And => a.IsPressed() && b.IsPressed(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            public override bool WasPressedThisFrame()
            {
                return mode switch
                {
                    Mode.Or => a.WasPressedThisFrame() || b.WasPressedThisFrame(),
                    Mode.And => a.WasPressedThisFrame() && b.WasPressedThisFrame(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            public override bool WasReleasedThisFrame()
            {
                return mode switch
                {
                    Mode.Or => a.WasReleasedThisFrame() || b.WasReleasedThisFrame(),
                    Mode.And => a.WasReleasedThisFrame() && b.WasReleasedThisFrame(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
        [SerializeField] private Mode mode;
        private enum Mode
        {
            WASD,
            Arrows,
            ArrowsAndWASD,
        }

        private static readonly KeyDPad wasdKeyDPad = new KeyDPad(
            new SingleKey(KeyCode.W), new SingleKey(KeyCode.A), 
            new SingleKey(KeyCode.S), new SingleKey(KeyCode.D));

        private static readonly KeyDPad arrowKeyDPad = new KeyDPad(
            new SingleKey(KeyCode.UpArrow), new SingleKey(KeyCode.LeftArrow),
            new SingleKey(KeyCode.DownArrow), new SingleKey(KeyCode.RightArrow));
        
        public Key North {
            get
            {
                return mode switch
                {
                    Mode.WASD => wasdKeyDPad.North,
                    Mode.Arrows => arrowKeyDPad.North,
                    Mode.ArrowsAndWASD => new KeyUnifier(wasdKeyDPad.North, arrowKeyDPad.North),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
        public Key South {
            get
            {
                return mode switch
                {
                    Mode.WASD => wasdKeyDPad.South,
                    Mode.Arrows => arrowKeyDPad.South,
                    Mode.ArrowsAndWASD => new KeyUnifier(wasdKeyDPad.South, arrowKeyDPad.South),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }        
        public Key West{
            get
            {
                return mode switch
                {
                    Mode.WASD => wasdKeyDPad.West,
                    Mode.Arrows => arrowKeyDPad.West,
                    Mode.ArrowsAndWASD => new KeyUnifier(wasdKeyDPad.West, arrowKeyDPad.West),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }        
        public Key East {
            get
            {
                return mode switch
                {
                    Mode.WASD => wasdKeyDPad.East,
                    Mode.Arrows => arrowKeyDPad.East,
                    Mode.ArrowsAndWASD => new KeyUnifier(wasdKeyDPad.East, arrowKeyDPad.East),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
    }
}