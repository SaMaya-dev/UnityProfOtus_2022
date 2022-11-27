using System;
using Elementary;
using UnityEngine;
using Zenject;

public class JumpComponent : MonoBehaviour, IJumpComponent
{
    [Inject] private CharacterService characterService;
    [SerializeField] private EventReceiver jumpReceiver;
    
    public void Jump()
    {
        jumpReceiver.Call();
    }
}
