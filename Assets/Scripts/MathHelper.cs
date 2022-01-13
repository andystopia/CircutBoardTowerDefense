public static class MathHelper
{
    /// <summary>
    ///     Calculates the proper mathematical mod
    ///     of a number.
    ///     That is for any value of b, no matter
    ///     the input of a this function
    ///     will return a value between 0 and b,
    ///     This is equivalent to python's mod
    ///     for integers.
    /// </summary>
    /// <param name="a"> the a parameter in a % b </param>
    /// <param name="b"> the b parameter in b % a </param>
    /// <returns></returns>
    public static int MathMod(int a, int b)
    {
        return (a % b + b) % b;
    }
}