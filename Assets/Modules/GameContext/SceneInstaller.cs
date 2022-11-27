using GameElements;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private BulletShooter bulletShooter;
    [SerializeField] private CharacterService characterService;
    public override void InstallBindings()
    {
        Container.Bind<BulletShooter>()
            .FromInstance(bulletShooter)
            .AsSingle();

        Container.Bind<CharacterService>().FromInstance(characterService).AsSingle();
        Container.BindInterfacesTo<GameEventReceiver>().AsSingle();
    }
}