using System;
using System.Collections.Generic;

public class ObseravableList<T>
{
    public event Action<T> Added;
    public event Action<T> Removed;

    private List<T> _elements = new();

    public List<T> Elements => _elements;

    public void Add(T element)
    {
        _elements.Add(element);
        Added?.Invoke(element);
    }

    public void Remove(T element)
    {
        _elements.Remove(element);
        Removed?.Invoke(element);
    }
}
