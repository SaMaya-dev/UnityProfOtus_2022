using Game.App;
using Zenject;


namespace Game.Gameplay.Player
{
    public sealed class MoneyMediator :
        IGameSetupListener,
        IGameSaveListener
    {
        private MoneyRepository repository;

        private MoneyStorage storage;

        [Inject]
        public void Construct(MoneyRepository repository)
        {
            this.repository = repository;
        }
        
        void IGameSetupListener.OnSetupGame(GameManager gameManager)
        {
            this.storage = gameManager.GetService<MoneyStorage>();
            this.LoadMoney();
        }

        void IGameSaveListener.OnSaveGame(GameSaveReason reason)
        {
            this.repository.SaveMoney(this.storage.Money);
        }
        
        private void LoadMoney()
        {
            if (!this.repository.LoadMoney(out var money))
            {
                var config = MoneyStorageConfig.LoadAsset();
                money = config.InitialMoney;
            }

            this.storage.SetupMoney(money);
        }
    }
}