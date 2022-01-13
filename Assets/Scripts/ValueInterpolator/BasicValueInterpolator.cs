using InterpolationFunction;

namespace ValueInterpolator
{
    public abstract class BasicValueInterpolator
    {
        protected BasicValueInterpolator(float startValue, float endValue,
            InterpolationFunction.InterpolationFunction interpolator)
        {
            StartValue = startValue;
            EndValue = endValue;
            Interpolator = interpolator;
        }

        /// <summary>
        ///     Retrieves the active value in the
        ///     interpolator.
        /// </summary>
        public abstract float CurrentValue { get; }

        /// <summary>
        ///     Gets the starting value to interpolate.
        /// </summary>
        public float StartValue { get; }

        public float EndValue { get; }

        public InterpolationFunction.InterpolationFunction Interpolator { get; }

        /// <summary>
        ///     Determines whether the interpolation
        ///     has finished it's interpolating.
        /// </summary>
        protected abstract bool IsAtEnd { get; }

        /// <summary>
        ///     Call this update once a frame from some
        ///     sort of MonoBehaviour, in order to advance
        ///     the interpolator.
        /// </summary>
        protected abstract void Update();

        /// <summary>
        ///     This method sort of "reverses" the interpolation,
        ///     but moreso what ever time, δ, has elapsed,
        ///     it will elapsed that same time δ, to get back
        ///     to the starting point.
        /// </summary>
        /// <returns></returns>
        protected abstract BasicValueInterpolator Invert();

        /// <summary>
        ///     Evaluate the interpolator at a given step t between [0, 1]
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        protected virtual float Evaluate(float t)
        {
            return InterpolationHelper.Lerp(StartValue, EndValue, Interpolator.Transform(t));
        }

        protected abstract BasicValueInterpolator Reset();
    }
}