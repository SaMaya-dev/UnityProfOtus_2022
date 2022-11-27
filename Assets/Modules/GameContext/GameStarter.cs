using System.Collections;
using Elementary;
using UnityEngine;
using Zenject;

public class GameStarter : MonoBehaviour
{
    [Inject] 
    private IGameGameEventReceiver gameGameEventReceiver;
    
    [SerializeField] 
    private TimerBehaviour timerBehaviour;

    private void Awake()
    {
        gameGameEventReceiver.GameFinished += RestartGame;
    }

    private IEnumerator Start()
    {
        timerBehaviour.OnFinished += OnTimerFinished;
        yield return new WaitForSeconds(1f);
        StartTimer();

    }
    
    private void RestartGame()
    {
        StartTimer();
    }

    private void StartTimer()
    {
        timerBehaviour.ResetTime();
        timerBehaviour.Play();
    }
    private void OnTimerFinished()
    {
        gameGameEventReceiver.StartGame();
    }

    private void OnDestroy()
    {
        timerBehaviour.OnFinished -= OnTimerFinished;
    }
}
