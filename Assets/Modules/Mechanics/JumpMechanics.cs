using Elementary;
using UnityEngine;

public class JumpMechanics : MonoBehaviour
{
    [SerializeField]
    private EventReceiver jumpReceiver;
    [SerializeField]
    private Vector3 jumpVector;


    [SerializeField] 
    private Rigidbody rigidbody;

    private void OnEnable()
    {
        jumpReceiver.OnEvent += OnJumpEvent;
    }

    private void OnDisable()
    {
        jumpReceiver.OnEvent -= OnJumpEvent;
    }

    private void OnJumpEvent()
    {
        rigidbody.AddForce(jumpVector);
    }
}
