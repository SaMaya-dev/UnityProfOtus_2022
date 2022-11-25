using System;
using UnityEngine;

public sealed class Entity : MonoBehaviour
{
    [SerializeField]
    private MonoBehaviour[] components;

    public T Get<T>()
    {
        foreach (var component in this.components)
        {
            if (component is T result)
            {
                return result;
            }
        }
            
        throw new Exception($"Component {typeof(T).Name} is not found!");
    }
}