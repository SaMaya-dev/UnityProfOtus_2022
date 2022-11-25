using System;
public interface IGameStarter
{
    event Action  GameStarted;

    void StartGame();
}
