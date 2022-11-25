using UnityEngine;
using Zenject;

public class WallsController : MonoBehaviour
{
    [Inject] 
    private IGameStarter gameStarter;

    [Inject] 
    private IGameFinisher gameFinisher;

    [SerializeField]
    private string checkCollisions;
    private void Awake()
    {
        gameStarter.GameStarted += OnGameStarted;
        gameFinisher.GameFinished += OnGameFinished;
        enabled = false;
    }

    private void OnGameFinished()
    {
        enabled = false;
    }

    private void OnGameStarted()
    {
        enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != checkCollisions)
            return;
        gameFinisher.GameOver();
    }

    private void OnDestroy()
    {
        gameStarter.GameStarted -= OnGameStarted;
        gameFinisher.GameFinished -= OnGameFinished;
    }
}
