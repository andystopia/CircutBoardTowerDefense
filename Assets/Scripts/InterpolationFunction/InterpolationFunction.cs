using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InterpolationFunction
{
    public interface InterpolationFunction
    {
        /// <summary>
        /// The function of the curve of the interpolation function.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public float Transform(float value);
    }


    /// <summary>
    /// Allows for custom interpolation functions to be written
    /// quickly, without generating a whole new class at the
    /// cost of one pointer indirection.
    ///
    /// </summary>
    /// <example>
    /// <code>
    /// // definition of a linear interpolator
    /// CustomInterpolator inter = new CustomInterpolator(x => x)
    /// </code>
    /// </example>
    public class CustomInterpolator : InterpolationFunction
    {
        private readonly Func<float, float> function;

        public CustomInterpolator(Func<float, float> function)
        {
            this.function = function;
        }

        public float Transform(float value)
        {
            return function.Invoke(value);
        }
    }
    
    public class PolynomialInterpolator : InterpolationFunction
    {
        public readonly float Degree;

        public static readonly PolynomialInterpolator Linear = new PolynomialInterpolator(1);
        public static readonly PolynomialInterpolator Quadratic = new PolynomialInterpolator(2);
        public static readonly PolynomialInterpolator Cubic = new PolynomialInterpolator(3);

        public PolynomialInterpolator(float degree)
        {
            Degree = degree;
        }

        public float Transform(float time)
        {
            return (float) Math.Pow(time, Degree);
        }
    }

    public class InversePolynomialInterpolator : InterpolationFunction
    {
        public readonly float Degree;

        public static readonly InversePolynomialInterpolator InverseQuadratic = new InversePolynomialInterpolator(2);
        public static readonly InversePolynomialInterpolator InverseCubic = new InversePolynomialInterpolator(3);

        public InversePolynomialInterpolator(float degree)
        {
            Degree = degree;
        }

        /// <summary>
        /// Curves the input to the time function so that
        /// it achieves an inverse polynomial style.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public float Transform(float time)
        {
            return (float) Math.Pow(time, 1.0f / Degree);
        }
    }

    public class EaseOutElastic : InterpolationFunction
    {
        private const float c4 = (float) (2 * Math.PI) / 3;

        /// <summary>
        /// Animates an "Ease Out Elastic" function,
        /// Pulled from https://easings.net/#easeOutElastic.
        ///
        /// Makes a sort of bouncing ending call.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public float Transform(float time)
        {
            if (time == 0)
            {
                return 0;
            }

            // if time == 1
            if (time > 1 - float.Epsilon)
            {
                return 1;
            }

            return (float) (Math.Pow(2, -10 * time) * Math.Sin((time * 10 - 0.75) * c4) + 1);
        }
    }



    /// <summary>
    /// This class is for those stateless interpolators, which
    /// are simple math functions, of the form f(x) = y for
    /// x and y ∈ R, where x is a time and y is a time.
    ///
    /// So things like linear are really simple, as
    /// are single term polynomials and inverse polynomials.
    /// </summary>

    /// <summary>
    /// Allows CSS-Style <c>bezier-curve()</c> animation
    /// control. A lot of flexible than a polynomial
    /// interpolation function.
    /// </summary>
    public class CubicBezierInterpolator : InterpolationFunction
    {
        // inputs to the cubic-bezier function.
        private readonly Vector2 p0 = Vector2.zero;
        private readonly Vector2 p1;
        private readonly Vector2 p2;
        private readonly Vector2 p3 = Vector2.one;

        /// <summary>
        /// You can turn this up, if you find the animation
        /// quality unsatisfactory, though it will make the
        /// animation more computationally expensive.
        /// </summary>
        private const int accuracy = 10;


        public static readonly CubicBezierInterpolator Ease = new CubicBezierInterpolator(0.25f, 0.1f, 0.25f, 1.0f);
        public static readonly CubicBezierInterpolator EaseIn = new CubicBezierInterpolator(0.42f, 0.0f, 1.0f, 1.0f);

        public static readonly CubicBezierInterpolator
            EaseInOut = new CubicBezierInterpolator(0.42f, 0.0f, 0.58f, 1.0f);

        public static readonly CubicBezierInterpolator EaseOut = new CubicBezierInterpolator(0.0f, 0.0f, 0.58f, 1.0f);

        public enum CSSName
        {
            Ease,
            EaseIn,
            EaseInOut,
            EaseOut,
        }

        /// <summary>
        /// Meant to be a compatible interpolator
        /// with CSS's cubic-bezier function,
        /// aka, the arguments that are passed to
        /// the css cubic bezier function can be passed
        /// straight to this one, with similar behavior.
        /// </summary>
        /// <param name="p1x">range [0, 1]</param>
        /// <param name="p1y">range (-inf, 1]</param>
        /// <param name="p2x">range [0, 1]</param>
        /// <param name="p2y">range [-1, inf)</param>
        public CubicBezierInterpolator(float p1x, float p1y, float p2x, float p2y)
        {
            // lots of bound checking so that way we can ensure that it actually makes sense
            // to animate using the inputs to this function.
            if (p1x < 0 || p1x > 1 || p1y > 1 || p1x < 0 || p2x > 1 || p2y < -1)
            {
                Debug.LogWarning(
                    $"Invalid cubic-bezier(${p1x}, ${p1y}, ${p2x}, ${p2y}), check the doc comment ranges, reverting to linear animation...");
                p1x = p1y = 0;
                p2x = p2y = 1;
            }


            p1.x = p1x;
            p1.y = p1y;

            p2.x = p2x;
            p2.y = p2y;
        }

        /// <summary>
        /// Converts from the CSSName to the bezier curve.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CubicBezierInterpolator fromCSSName(CSSName name)
        {
            return name switch
            {
                CSSName.Ease => Ease,
                CSSName.EaseIn => EaseIn,
                CSSName.EaseInOut => EaseInOut,
                CSSName.EaseOut => EaseOut,
                _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
            };
        }

        /// <summary>
        /// Cubic-Bezier Function Definition.
        /// </summary>
        /// <param name="t"> the input to the cubic bezier function</param>
        /// <returns></returns>
        private Vector2 At(float t)
        {
            // sorry this hard to read, it's just a transliteration 
            // of a math equation.
            return p0 * (float) Math.Pow(1 - t, 3) + p1 * (3 * (float) Math.Pow(1 - t, 2) * t) +
                   p2 * (3 * (1 - t) * (float) Math.Pow(t, 2)) + p3 * (float) Math.Pow(t, 3);
        }

        /// <summary>
        /// The derivative of the cubic bezier function definition
        /// Basically only useful for evaluating the <c>FindXOutput</c>
        /// function.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private Vector2 Derivative(float t)
        {
            // sorry this hard to read, it's just a transliteration 
            // of a math equation.
            return (p1 - p0) * 3 * (float) Math.Pow(1 - t, 2) + (p2 - p1) * 6 * (1 - t) * t +
                   (p3 - p2) * 3 * (float) Math.Pow(t, 2);
        }


        /// <summary>
        /// uses the Newton-Raphson method
        /// of approximating roots in order to
        /// figure out which x, as an input will yield
        /// a t which will make the <c>at<c> function
        /// yield an output with x as the first component
        /// of the vector.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private float FindXOutput(float x)
        {
            // start in the middle of the function's range.
            float better = 0.5f;
            for (int i = 0; i < accuracy; i++)
            {
                better -= (At(better).x - x) / Derivative(better).x;
            }

            return better;
        }
        

        public float Transform(float time)
        {
            return At(FindXOutput(time)).y;
        }
    }
}
