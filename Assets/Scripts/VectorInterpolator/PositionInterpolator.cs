using JetBrains.Annotations;
using UnityEngine;

namespace VectorInterpolator
{
    public class PositionInterpolator
    {
        [NotNull] private readonly Transform transform;
        [NotNull] private readonly VectorInterpolator vectorInterpolator;

        public PositionInterpolator(int animationFrameDuration, Vector3 start, Vector3 end,
            [NotNull] InterpolationFunction.InterpolationFunction function,
            [NotNull] Transform transform)
        {
            this.transform = transform;
            vectorInterpolator = new VectorInterpolator(start, end, animationFrameDuration, function);
        }

        /// <summary>
        ///     Returns true if the animation is complete,
        ///     otherwise false.
        /// </summary>
        public bool IsComplete => vectorInterpolator.IsComplete;


        /// <summary>
        ///     Returns how far the animation has progressed.
        /// </summary>
        public float PercentComplete => vectorInterpolator.PercentComplete;


        /// <summary>
        ///     call this method every time you want the animation
        ///     to take a step towards completion.
        /// </summary>
        public void Update()
        {
            vectorInterpolator.Update();
            transform.position = vectorInterpolator.CurrentValue;
        }
    }
}