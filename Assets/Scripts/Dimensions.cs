/// <summary>
/// A general class that represents the dimensions
/// of "something" it's just meant to be a general
/// storage class.
/// </summary>
/// <typeparam name="T"> the type of the dimensions </typeparam>
public struct Dimensions<T>
{
    /// <summary>
    /// The width of the dimensions
    /// </summary>
    public readonly T width;
    /// <summary>
    /// The height of the dimensions.
    /// </summary>
    public readonly T height;

    /// <summary>
    /// Creates a new Dimensions artifact with a given
    /// width and height
    /// </summary>
    /// <param name="width"> the width </param>
    /// <param name="height"> the height </param>
    public Dimensions(T width, T height)
    {
        this.width = width;
        this.height = height;
    }

    public override string ToString()
    {
        return $"Dimensions : <{width}, {height}>";
    }
}
