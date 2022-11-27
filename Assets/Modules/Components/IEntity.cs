using UnityEngine;

public interface IEntity
{
    T Get<T>();

    T[] GetAll<T>();

    bool TryGet<T>(out T element);

    object[] GetAll();

    void Add(Component element);

    void Remove(Component element);
}