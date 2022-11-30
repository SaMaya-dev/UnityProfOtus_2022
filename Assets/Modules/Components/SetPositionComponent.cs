using UnityEngine;

public class SetPositionComponent : MonoBehaviour, ISetPositionComponent
{
    [SerializeField] private Transform visualObject;

    public void Set(Vector3 position)
    {
        visualObject.transform.position = position;
    }
}