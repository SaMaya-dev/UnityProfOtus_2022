using System.Collections;
using System.Collections.Generic;
using Elementary;
using UnityEngine;

public class JumpMechanics : MonoBehaviour
{
    [SerializeField]
    private EventReciever_Vector jumpReceiver;

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

    private void OnJumpEvent(Vector3 v)
    {
        rigidbody.AddForce(v);
    }
}
