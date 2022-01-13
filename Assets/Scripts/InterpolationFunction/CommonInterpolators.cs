using System;

namespace InterpolationFunction
{
    public enum CommonInterpolators
    {
        Ease,
        EaseIn,
        EaseInOut,
        EaseOut,
        Linear,
        Quadratic,
        Cubic,
        InverseQuadratic,
        InverseCubic,
        EaseOutElastic,
    }
    internal static class CommonInterpolatorExtensions
    {
        public static InterpolationFunction GetInterpolationFunction(this CommonInterpolators interpolators)
        {
            return interpolators switch
            {
                CommonInterpolators.Ease => CubicBezierInterpolator.Ease,
                CommonInterpolators.EaseIn => CubicBezierInterpolator.EaseIn,
                CommonInterpolators.EaseInOut => CubicBezierInterpolator.EaseInOut,
                CommonInterpolators.EaseOut => CubicBezierInterpolator.EaseOut,
                CommonInterpolators.Linear => PolynomialInterpolator.Linear,
                CommonInterpolators.Quadratic => PolynomialInterpolator.Quadratic,
                CommonInterpolators.Cubic => PolynomialInterpolator.Cubic,
                CommonInterpolators.InverseQuadratic => InversePolynomialInterpolator.InverseQuadratic,
                CommonInterpolators.InverseCubic => InversePolynomialInterpolator.InverseCubic,
                CommonInterpolators.EaseOutElastic => new EaseOutElastic(),
                _ => throw new ArgumentOutOfRangeException(nameof(interpolators), interpolators, null)
            };
        }
    }

}

