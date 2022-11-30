using System;
public interface IGameEventReceiver
{
    event Action  GameStarted;
    event Action GameFinished;
    void StartGame();
    
    void GameOver();

    void Win();

}
