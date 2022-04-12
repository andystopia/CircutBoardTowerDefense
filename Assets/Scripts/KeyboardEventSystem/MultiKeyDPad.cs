using UnityEngine;

namespace KeyboardEventSystem
{
    [System.Serializable]
    public class MultiKeyDPad
    {
            [SerializeField] private MultiKey north;
            [SerializeField] private MultiKey west;
            [SerializeField] private MultiKey south;
            [SerializeField] private MultiKey east;

            public MultiKey North => north;
            public MultiKey West => west;
            public MultiKey South => south;
            public MultiKey East => east;
    }
}