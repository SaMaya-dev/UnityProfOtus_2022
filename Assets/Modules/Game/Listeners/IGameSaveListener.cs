namespace Game.App
{
    public interface IGameSaveListener
    {
        void OnSaveGame(GameSaveReason reason);
    }
}