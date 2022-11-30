using Game.GameEngine;
using UIFrames;
using UnityEngine;
using Upgrades;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private BulletShooter bulletShooter;
    [SerializeField] private CharacterService characterService;
    [SerializeField] private PopupManager popupManager;
    [SerializeField] private PlayerUpgrader playerUpgrader;
    [SerializeField] private UpgradeModelFactory upgradeModelFactory;
    
    public override void InstallBindings()
    {
        Container.Bind<BulletShooter>()
            .FromInstance(bulletShooter)
            .AsSingle();

        Container.Bind<CharacterService>().FromInstance(characterService).AsSingle();
        Container.Bind<PlayerUpgrader>().FromInstance(playerUpgrader).AsSingle();
        Container.Bind<UpgradeModelFactory>().FromInstance(upgradeModelFactory).AsSingle();
        Container.Bind<IPopupManager<PopupName>>().FromInstance(popupManager).AsSingle();
        Container.BindInterfacesTo<GameEventReceiver>().AsSingle();
    }
}