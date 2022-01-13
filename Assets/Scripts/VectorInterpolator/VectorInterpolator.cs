using JetBrains.Annotations;
using UnityEngine;

namespace VectorInterpolator
{
    internal readonly struct InterpolationStateManager
    {
        private readonly VectorInterpolationFunction function;

        public InterpolationStateManager(Vector3 start, Vector3 end, VectorInterpolationFunction function)
        {
            this.Start = start;
            this.End = end;
            this.function = function;
        }

        /// <summary>
        ///     The place to start the interpolation
        /// </summary>
        public Vector3 Start { get; }

        /// <summary>
        ///     The place to end the interpolation.
        /// </summary>
        public Vector3 End { get; }

        public Vector3 positionAtTime(float time)
        {
            return function.PositionAtTime(Start, End, time);
        }
    }

    internal class VectorInterpolator
    {
        private readonly int animationFrameDuration;
        private readonly InterpolationStateManager interpolationState;
        private int elapsedFrames;


        public VectorInterpolator(Vector3 start, Vector3 end, int animationFrameDuration,
            [NotNull] InterpolationFunction.InterpolationFunction interpolator)
        {
            this.animationFrameDuration = animationFrameDuration;
            interpolationState =
                new InterpolationStateManager(start, end, new VectorInterpolationFunction(interpolator));
            // have the animation start at, well, the start.
            CurrentValue = interpolationState.Start;
        }

        /// <summary>
        ///     Auto-Property that contains the current
        ///     position of the interpolator.
        /// </summary>
        public Vector3 CurrentValue { get; private set; }


        /// <summary>
        ///     Returns true if the animation has completed.
        /// </summary>
        public bool IsComplete => animationFrameDuration == elapsedFrames;

        /// <summary>
        ///     A value between 0.0f and 1.0f representing how
        ///     close the animation is to completion.
        ///     Do not make the assumption that at 0.5
        ///     the object is half way to it's destination,
        ///     that assumption only holds true for some
        ///     interpolation functions (e.g. linear).
        /// </summary>
        public float PercentComplete => (float) elapsedFrames / animationFrameDuration;

        /// <summary>
        ///     call this method every time you want the animation
        ///     to take a step towards completion.
        /// </summary>
        public void Update()
        {
            if (IsComplete)
            {
                CurrentValue = interpolationState.End;
            }
            else
            {
                elapsedFrames += 1;
                CurrentValue = interpolationState.positionAtTime(PercentComplete);
            }
        }
    }
}