using System;
public interface IGameGameEventReceiver
{
    event Action  GameStarted;
    event Action GameFinished;
    void StartGame();
    
    void GameOver();

    void Win();

}
