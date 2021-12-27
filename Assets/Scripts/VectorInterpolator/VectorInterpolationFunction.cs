using Vector3 = UnityEngine.Vector3;

namespace VectorInterpolator
{
    public class VectorInterpolationFunction
    {
        private readonly InterpolationFunction.InterpolationFunction interpolationFunction;


        public VectorInterpolationFunction(InterpolationFunction.InterpolationFunction interpolationFunction)
        {
            this.interpolationFunction = interpolationFunction;
        }

        public  Vector3 PositionAtTime(Vector3 start, Vector3 end, float time)
        {
            return Vector3.LerpUnclamped(start, end, interpolationFunction.Transform(time));
        }
    }
}