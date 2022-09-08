using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class MeshCutInstaller : MonoInstaller
{
    [Inject]
    Settings _settings = null;

    public override void InstallBindings()
    {
        Container.Bind<ILineConstructable>().To<LineConstructer>().AsSingle().NonLazy();
        Container.Bind<IMeshCreatable>().To<MeshCreator>().AsSingle().NonLazy();
        Container.Bind<GameController>().AsSingle().NonLazy();

        Container.BindFactory<PieceSide, Mesh, PlanePiece, PlanePiece.Factory>()
            .FromComponentInNewPrefab(_settings.planePiecePrefab)
            .WithGameObjectName("PlanePiece")
            .UnderTransformGroup("Plane");

        Container.Bind<ClothDensitySetter>()
            .FromNewComponentOnNewGameObject()
            .WithGameObjectName("Cloth Density")
            .UnderTransformGroup("Plane")
            .AsTransient();

        Container.Bind<DistanceSetter>().AsSingle();

        Container.Bind<UserInput>()
            .FromNewComponentOnNewGameObject()
            .WithGameObjectName("UserInput")
            .AsSingle().NonLazy();

        Container.Bind<PlayerMovement>()
            .FromComponentInNewPrefab(_settings.playerModel)
            .WithGameObjectName("Player")
            .UnderTransformGroup("UserInput")
            .AsSingle().NonLazy();

        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<FinishedPlayerSignal>();




    }

    [Serializable]
    public class Settings
	{
        public PlanePiece planePiecePrefab;
        public GameObject playerModel;
    }

}
 