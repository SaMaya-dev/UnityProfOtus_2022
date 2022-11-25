using Elementary;
using UnityEngine;

public sealed class MoveComponent : MonoBehaviour, IMoveComponent
{
    [SerializeField] private EventReceiver_Vector moveReceiver;
    public void Move(Vector3 direction)
    {
        moveReceiver.Call(direction);
    }
}
