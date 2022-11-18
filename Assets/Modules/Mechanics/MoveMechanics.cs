
using System.Collections;
using Elementary;
using UnityEngine;

public class MoveMechanics : MonoBehaviour
{
    [SerializeField]
    private EventReciever_Vector moveReceiver;
    
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
        if (isMoving) return;
        StartCoroutine(Move(v));
    }
    
    private IEnumerator Move(Vector3 posB)
    {
        isMoving = true;
        float startTime = Time.time;
        var deltaTime = Time.time - startTime;
        var posA = moveObject.transform.localPosition;
        while (deltaTime <= 1f)
        {
            deltaTime = Time.time - startTime;
            moveObject.transform.localPosition = Vector3.Lerp(posA, posB, deltaTime);
            yield return null;
        }

        isMoving = false;
    }
}
