namespace ValueInterpolator
{
    /// <summary>
    ///     This class calculates frame
    ///     based interpolation values
    /// </summary>
    public class FrameBasedInterpolator : BasicValueInterpolator
    {
        private readonly int frames;
        private int currentFrame;


        public FrameBasedInterpolator(float startValue, float endValue, int frames,
            InterpolationFunction.InterpolationFunction interpolationFunc) : base(startValue, endValue,
            interpolationFunc)
        {
            this.frames = frames;
            currentFrame = 0;
        }

        /// <summary>
        ///     Retrieves the active value in the
        ///     interpolator.
        /// </summary>
        public override float CurrentValue => Evaluate((float) currentFrame / frames);

        /// <summary>
        ///     Determines whether the interpolation
        ///     has finished it's interpolating.
        /// </summary>
        protected override bool IsAtEnd => currentFrame >= frames;

        /// <summary>
        ///     Call this update once a frame from some
        ///     sort of MonoBehaviour, in order to advance
        ///     the interpolator.
        /// </summary>
        protected override void Update()
        {
            // don't allow the current frames to 
            // exceed the frame count.
            if (currentFrame >= frames) return;
            currentFrame++;
        }


        /// <summary>
        ///     This method sort of "reverses" the interpolation,
        ///     but moreso what ever time, δ, has elapsed,
        ///     it will elapsed that same time δ, to get back
        ///     to the starting point.
        /// </summary>
        /// <returns></returns>
        protected override BasicValueInterpolator Invert()
        {
            // right, because we want to reverse our interpolation to the extent that we basically are undoing
            // what we've already done over the number of frames that we've already done.
            return new FrameBasedInterpolator(CurrentValue, StartValue, currentFrame, Interpolator);
        }

        /// <summary>
        ///     Create a new object which follows this interpolator
        ///     exactly. Useful if you want to repeat an interpolation
        ///     between the same couple of values.
        /// </summary>
        /// <returns></returns>
        protected override BasicValueInterpolator Reset()
        {
            return new FrameBasedInterpolator(StartValue, EndValue, frames, Interpolator);
        }
    }
}