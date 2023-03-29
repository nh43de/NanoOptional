using System;

namespace Nh43de;

public struct NanoOptional<T>
{
    private readonly T _value;

    public T Value
    {
        get
        {
            if (HasValue == false)
                throw new Exception("Value is null");

            return _value;
        }
    }

    public bool HasValue { get; set; }

    public NanoOptional(T value)
    {
        _value = value;
        HasValue = true;
    }

    public NanoOptional()
    {
        HasValue = false;
        _value = default;
    }
    
    public override string ToString()
    {
        if (HasValue)
            return Value.ToString();

        return (string)null;
    }

    /// <summary>
    /// Implicit cast from the vale to the optional.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The optional value.</returns>
    public static implicit operator NanoOptional<T>(T value) => ToOptional(value);

    public static implicit operator NanoOptional<T>(NoValue noValue)
    {
        return NanoOptional<T>.Null;
    }

    public class NoValue { }


    /// <summary>
    /// Gets the optional from a value.
    /// </summary>
    /// <param name="value">The value to get the optional for.</param>
    /// <returns>The optional.</returns>
    public static NanoOptional<T> ToOptional(T value) => new(value);

    public static NanoOptional<T> Null = new();



    /// <summary>Indicate whether two keys are not equal</summary>
    /// <param name="x">The first to compare.</param>
    /// <param name="y">The second to compare.</param>
    public static bool operator !=(NanoOptional<T> x, NanoOptional<T> y)
    {
        return !(x == y);
    }

    /// <summary>Indicate whether two keys are not equal</summary>
    /// <param name="x">The first to compare.</param>
    /// <param name="y">The second to compare.</param>
    public static bool operator !=(T x, NanoOptional<T> y)
    {
        return !(x == y);
    }

    /// <summary>Indicate whether two keys are not equal</summary>
    /// <param name="x">The first to compare.</param>
    /// <param name="y">The second to compare.</param>
    public static bool operator !=(NanoOptional<T> x, T y)
    {
        return !(x == y);
    }

    private static bool CompositeEquals(NanoOptional<T> keyValue0, NanoOptional<T> keyValue1)
    {
        if (keyValue0.HasValue == false || keyValue1.HasValue == false)
            return false;

        return keyValue0.Equals(keyValue1);
    }
    
    /// <summary>Indicate whether two keys are equal</summary>
    /// <param name="x">The first to compare.</param>
    /// <param name="y">The second to compare.</param>
    public static bool operator ==(NanoOptional<T> x, NanoOptional<T> y)
    {
        return CompositeEquals(x, y);
    }

    /// <summary>Indicate whether two keys are equal</summary>
    /// <param name="x">The first to compare.</param>
    /// <param name="y">The second to compare.</param>
    public static bool operator ==(T x, NanoOptional<T> y)
    {
        return CompositeEquals((NanoOptional<T>)x, y);
    }

    /// <summary>Indicate whether two keys are equal</summary>
    /// <param name="x">The first to compare.</param>
    /// <param name="y">The second to compare.</param>
    public static bool operator ==(NanoOptional<T> x, T y)
    {
        return CompositeEquals(x, (NanoOptional<T>)y);
    }
    
    public override bool Equals(object obj)
    {
        object obj1;

        if ((obj1 = obj) is NanoOptional<T>)
        {
            var currencyKey = (NanoOptional<T>)obj1;
            return CompositeEquals(this, currencyKey);
        }

        if (obj is T s)
            return CompositeEquals(this, s);

        return false;
    }

    /// <summary>Indicate whether two keys are equal</summary>
    /// <param name="other">The <see cref="T:BotFramework.Core.Models.Structs.Currency" /> to compare to.</param>
    public bool Equals(NanoOptional<T> other)
    {
        return CompositeEquals(this, other);
    }

    /// <summary>See Object.GetHashCode</summary>
    public override int GetHashCode()
    {
        if (this.HasValue == false)
            return -1;

        return Value.GetHashCode();
    }

    public new bool Equals(object x, object y)
    {
        return CompositeEquals(((NanoOptional<T>)x), ((NanoOptional<T>)y));
    }
}
