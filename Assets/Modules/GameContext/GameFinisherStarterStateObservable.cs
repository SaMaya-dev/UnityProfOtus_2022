using System;
using UnityEngine;

public class  GameFinisherStarterStateObservable : IGameStarter, IGameFinisher
{
    public event Action GameStarted;
    public event Action GameFinished;

    public void StartGame()
    {
        GameStarted?.Invoke();
        Debug.Log("Game Started!");
    }
    
    public void GameOver()
    {
        GameFinished?.Invoke();
        Debug.Log("Game Over!");
    }

}
