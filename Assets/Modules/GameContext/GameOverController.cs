using UnityEngine;
using Zenject;

public class GameOverController : MonoBehaviour
{
    [Inject] 
    private IGameGameEventReceiver gameGameEventReceiver;
    
    [SerializeField]
    private string checkCollisions;
    private void OnEnable()
    {
        gameGameEventReceiver.GameStarted += OnGameStarted;
        gameGameEventReceiver.GameFinished += OnGameFinished;
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
        gameGameEventReceiver.GameOver();
    }

    private void OnDisable()
    {
        gameGameEventReceiver.GameStarted -= OnGameStarted;
        gameGameEventReceiver.GameFinished -= OnGameFinished;
    }
}
