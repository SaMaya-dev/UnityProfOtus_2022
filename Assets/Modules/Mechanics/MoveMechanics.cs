
using System.Collections;
using Elementary;
using UnityEngine;

public class MoveMechanics : MonoBehaviour
{
    [SerializeField]
    private EventReceiver_Vector moveReceiver;
    
    [SerializeField] 
    private GameObject moveObject;

    private bool isMoving;
    
    private void OnEnable()
    {
        moveReceiver.OnEvent += OnMoveEvent;
    }

    private void OnDisable()
    {
        moveReceiver.OnEvent -= OnMoveEvent;
    }

    private void OnMoveEvent(Vector3 v)
    {
       
        moveObject.transform.position += v;
    }

}
