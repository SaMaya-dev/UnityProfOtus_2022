using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class RestartPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObject;

    [Inject] 
    private IGameStarter GameFinisher;
    
    private Vector3 defaultPosition;
    private void Awake()
    {
        defaultPosition = gameObject.transform.position;
        GameFinisher.GameStarted += Reposition;
    }

    private void Reposition()
    {
        gameObject.transform.position = defaultPosition;
    }

    private void OnDestroy()
    {
        GameFinisher.GameStarted -= Reposition;
    }
}
