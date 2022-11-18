using System.Collections;
using System.Collections.Generic;
using Elementary;
using UnityEngine;

public class JumpMechanics : MonoBehaviour
{
    [SerializeField]
    private EventReceiver jumpReceiver;

    [SerializeField] 
    private Rigidbody rigidbody;

    [SerializeField] 
    private Vector3 jumpForce;
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
        rigidbody.AddForce(jumpForce);
    }
}
