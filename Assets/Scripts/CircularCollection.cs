using System.Collections.Generic;

/// <summary>
///     Represents a circular collection of
///     items, where we can get the focused
///     item and we can advance and unadvance it.
///     The default state is the
/// </summary>
/// <typeparam name="T"></typeparam>
public class CircularCollection<T> where T : class
{
    private readonly IList<T> collection;
    private int index;


    public CircularCollection(IList<T> items)
    {
        collection = items;
    }

    public int Count => collection.Count;

    public bool IsValid => collection.Count > 0;


    public T GetActive()
    {
        if (!IsValid) return null;
        return collection[index];
    }

    public T MoveToNext()
    {
        return MoveForwards(1);
    }


    public T MoveToPrevious()
    {
        return MoveBackwards(1);
    }

    public T MoveBackwards(int places)
    {
        return MoveForwards(-places);
    }


    public T MoveForwards(int places)
    {
        if (!IsValid) return null;
        index += places;
        index = MathHelper.MathMod(index, Count);
        return collection[index];
    }

    public bool SetIndex(int idx)
    {
        if (idx >= Count || idx <= 0) return false;
        index = idx;
        return true;
    }

    public IList<T> GetList()
    {
        return collection;
    }
}