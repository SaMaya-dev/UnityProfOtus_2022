using UnityEngine;
using Zenject;

public class GameOverController : MonoBehaviour
{
    [Inject] 
    private IGameEventReceiver gameEventReceiver;
    
    [SerializeField]
    private string checkCollisions;
    private void OnEnable()
    {
        gameEventReceiver.GameStarted += OnGameStarted;
        gameEventReceiver.GameFinished += OnGameFinished;
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
        if (other.CompareTag(checkCollisions))
            return;
        gameEventReceiver.GameOver();
    }

    private void OnDisable()
    {
        gameEventReceiver.GameStarted -= OnGameStarted;
        gameEventReceiver.GameFinished -= OnGameFinished;
    }
}
