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

        Container.BindInterfacesTo<GameFinisherStarterStateObservable>().AsSingle();
        
        //Container.Bind<IFinishGame>().To<GameContext>().AsSingle();
        //Container.Bind<IStartGame>().To<GameContext>().AsSingle();
    }
}