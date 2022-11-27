using System;
using UnityEngine;

public class  GameEventReceiver : IGameGameEventReceiver
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

    public void Win()
    {
        throw new NotImplementedException();
    }
}