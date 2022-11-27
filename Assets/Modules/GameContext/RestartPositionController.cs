using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class RestartPositionController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObject;

    [Inject] 
    private IGameGameEventReceiver GameFinisher;
    
    private Vector3 defaultPosition;
    private void Awake()
    {
        defaultPosition = gameObject.transform.position;
        GameFinisher.GameStarted += RestartPosition;
    }

    private void RestartPosition()
    {
        gameObject.transform.position = defaultPosition;
    }

    private void OnDestroy()
    {
        GameFinisher.GameStarted -= RestartPosition;
    }
}
