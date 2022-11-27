using GameElements;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private BulletShooter bulletShooter;
    public override void InstallBindings()
    {
        Container.Bind<BulletShooter>()
            .FromInstance(bulletShooter)
            .AsSingle();

        Container.Bind<CharacterService>().AsSingle();
        Container.BindInterfacesTo<GameEventReceiver>().AsSingle();
    }
}