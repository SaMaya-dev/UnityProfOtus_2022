using System;
using Entities;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public sealed class InputController : MonoBehaviour
{
    [SerializeField] private Entity unit;
    [Inject] private IGameStarter gameStarter;
    [Inject] private IGameFinisher gameFinisher;
    
    private void Awake()
    {
        enabled = false;
        gameStarter.GameStarted += OnGameStarted;
        gameFinisher.GameFinished += OnGameFinished;
    }

    private void OnGameFinished()
    {
        enabled = false;
    }

    private void OnGameStarted()
    {
        enabled = true;
    }

    private void Update()
    {
        this.HandleKeyboard();
    }

    private void HandleKeyboard()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.Move(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.Move(Vector3.back);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.Move(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.Move(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            this.Jump();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            this.Shoot();
        }
    }  

    private void Move(Vector3 direction)
    {
        const float speed = 5.0f;
        this.unit.Get<IMoveComponent>().Move(direction * (speed * Time.deltaTime));
    }
    
    private void Jump()
    {
        const float speed = 5.0f;
        this.unit.Get<IJumpComponent>().Jump();
    }
    
    private void Shoot()
    {
        const float speed = 5.0f;
        this.unit.Get<IShootComponent>().Shoot();
    }

    private void OnDestroy()
    {
        gameStarter.GameStarted -= OnGameStarted;
        gameFinisher.GameFinished -= OnGameFinished;
    }
}