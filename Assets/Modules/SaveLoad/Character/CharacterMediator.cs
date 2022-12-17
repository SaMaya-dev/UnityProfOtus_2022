using GameElements;
using Services;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class CharacterMediator : IGameDataLoader, IGameDataSaver
    {
        private CharacterRepository repository;

        [Inject]
        public void Construct(CharacterRepository repository)
        {
            this.repository = repository;
        }

        void IGameDataLoader.LoadData(IGameContext context)
        {
            if (this.repository.LoadStats(out CharacterData data))
            {
                IEntity character = context.GetService<CharacterService>().GetCharacter();
                CharacterConverter.SetupStats(character, data);
            }
        }

        void IGameDataSaver.SaveData(IGameContext context)
        {
            var character = context.GetService<CharacterService>().GetCharacter();
            var data = CharacterConverter.ConvertToData(character);
            this.repository.SaveStats(data);
        }
    }
}