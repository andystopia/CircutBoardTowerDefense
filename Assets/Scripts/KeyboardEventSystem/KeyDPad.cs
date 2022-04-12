using UnityEngine;

namespace KeyboardEventSystem
{
    [System.Serializable]
    public class KeyDPad
    {
        [SerializeField] private SingleKey north;
        [SerializeField] private SingleKey west;
        [SerializeField] private SingleKey south;
        [SerializeField] private SingleKey east;

        public SingleKey North => north;
        public SingleKey West => west;
        public SingleKey South => south;
        public SingleKey East => east;

        public KeyDPad(SingleKey north, SingleKey west, SingleKey south, SingleKey east)
        {
            this.north = north;
            this.west = west;
            this.south = south;
            this.east = east;
        }

        public override string ToString()
        {
            return $"North: {North}, West: {West}, South: {South}, East: {East}"; 
        }
    }
}