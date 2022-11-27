using System.Collections.Generic;
using Entities;
using UnityEngine;

public sealed class Entity : MonoBehaviour, IEntity
{
    [SerializeField]
    private List<object> components;

    public Entity()
    {
        this.components = new List<object>();
    }

    public Entity(IEnumerable<object> elements)
    {
        this.components = new List<object>(elements);
    }

    public Entity(params object[] elements)
    {
        this.components = new List<object>(elements);
    }

    public T Get<T>()
    {
        for (int i = 0, count = this.components.Count; i < count; i++)
        {
            if (this.components[i] is T result)
            {
                return result;
            }
        }

        throw new EntityException($"Element of type {typeof(T).Name} is not found!");
    }

    public T[] GetAll<T>()
    {
        var result = new List<T>();
        for (int i = 0, count = this.components.Count; i < count; i++)
        {
            if (this.components[i] is T element)
            {
                result.Add(element);
            }
        }

        return result.ToArray();
    }

    public object[] GetAll()
    {
        return this.components.ToArray();
    }

    public void Add(object element)
    {
        this.components.Add(element);
    }

    public void Remove(object element)
    {
        this.components.Remove(element);
    }

    public bool TryGet<T>(out T element)
    {
        for (int i = 0, count = this.components.Count; i < count; i++)
        {
            if (this.components[i] is T result)
            {
                element = result;
                return true;
            }
        }

        element = default;
        return false;
    }
}
