using System;
public interface IGameFinisher
{
    event Action GameFinished;

    void GameOver();
}
