using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class RestartPositionController : MonoBehaviour
{
    [Inject] 
    private CharacterService characterService;

    [Inject] 
    private IGameEventReceiver GameFinisher;
    
    private Vector3 defaultPosition;
    private void Awake()
    {
        defaultPosition = gameObject.transform.position;
        GameFinisher.GameStarted += RestartPosition;
    }

    private void RestartPosition()
    {
        characterService.GetCharacter().Get<ISetPositionComponent>().Set(defaultPosition);
    }

    private void OnDestroy()
    {
        GameFinisher.GameStarted -= RestartPosition;
    }
}
