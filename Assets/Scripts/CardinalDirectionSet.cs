
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using UnityEditor.SceneManagement;


public abstract class EnumSet<T> : IEnumerable where T : Enum
{
    public abstract void Add(T value);
    public abstract void Remove(T value);
    public abstract bool Contains(T value);


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public abstract IEnumerator<T> GetEnumerator();
}

/// <summary>
/// this is a hash set backed enum.
/// I'm a little concerned that it could
/// be slow. So I wrote up another one
/// with a different backing, so if
/// we need the performance, we can
/// use that one.
/// </summary>
/// <typeparam name="T"></typeparam>
public class EnumSetHashSet<T> : EnumSet<T> where T : Enum
{
    private readonly HashSet<T> values;

    public EnumSetHashSet()
    {
        values = new HashSet<T>();
    }

    public override bool Contains(T item)
    {
        return values.Contains(item);
    }

    public override void Remove(T item)
    {
        values.Remove(item);
    }

    public override void Add(T item)
    {
        values.Add(item);
    }

    public override IEnumerator<T> GetEnumerator()
    {
        return values.GetEnumerator();
    }
}

public class EnumSetBitVec32<T> : EnumSet<T> where T : Enum
{
    // as long as the vector has no value
    // that exceeds the number 32, we are a-okay.
    // and I think we can rely on that.
    private BitVector32 variants;
    

    /// <summary>
    /// from https://stackoverflow.com/questions/16960555/how-do-i-cast-a-generic-enum-to-int/51025027.
    ///
    /// thought it was slick enough to snag.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    private static int EnumToInt<TValue>(TValue value) where TValue : Enum => (int)(object)value;
    
    
    private IEnumerable<CardinalDirection> GetEnabledValues()
    {
        return Enum.GetValues(typeof(CardinalDirection)).Cast<CardinalDirection>().Where(value => variants[(int) value]);
    }

    public override void Add(T value)
    {
        SetVariantExistent(value, true);
    }

    public override void Remove(T value)
    {
        SetVariantExistent(value, false);
    }

    /// <summary>
    /// Sets whether this set contains the given variant
    /// or not.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="exists"></param>
    private void SetVariantExistent(T value, bool exists)
    {
        variants[EnumToInt(value)] = exists;
    }

    public override bool Contains(T value)
    {
        return variants[EnumToInt(value)];
    }

    public override IEnumerator<T> GetEnumerator()
    {
        // we can be pretty sure that one is pretty safe.
        return GetEnabledValues().GetEnumerator() as IEnumerator<T>;
    }
}