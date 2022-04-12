using UnityEngine;

namespace KeyboardEventSystem
{
    [System.Serializable]
    public class MultiKeyHorizontalAxis
    {
        [SerializeField] private MultiKey west;
        [SerializeField] private MultiKey east;

        /// <summary>
        /// The Westward Direction of the Axis
        /// </summary>
        public MultiKey West => west;
        /// <summary>
        /// The eastward direction of the axis.
        /// </summary>
        public MultiKey East => east;
    }
}