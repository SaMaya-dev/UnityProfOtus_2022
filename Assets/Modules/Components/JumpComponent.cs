using Elementary;
using UnityEngine;

public class JumpComponent : MonoBehaviour, IJumpComponent
{
    [SerializeField] private EventReceiver jumpReceiver;
    public void Jump()
    {
        jumpReceiver.Call();
    }
}
