using GameElements;

namespace Lessons.Architecture.SaveLoad
{
    //Интерфейс для загрузки данных в игру
    public interface IGameDataLoader
    {
        void LoadData(IGameContext context);
    }
}