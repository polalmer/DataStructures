using System.Collections;

namespace DataTypes;

public class List<T> : IList<T>
{
    private T[] items;

    public int Count {get; private set;}

    public List()
    {
        items = new T[10];
        Count = 0;
    } 


    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool IsReadOnly {get => false;}

    public void Add(T item)
    {
        EnsureCapacity();
        items[Count++] = item;
    }

    public void Clear()
    {
        items = new T[4];
        Count = 0;
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    private void EnsureCapacity()
    {
        if (Count == items.Length)
        {
            int newCapacity = items.Length * 2;
            Array.Resize(ref items, newCapacity);
        }
    }
}