using System;
using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller, IInitializable
{
    [Header("Hero Values")]
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _playerPrefab;
    [Header("Moving Objects Points")]
    [SerializeField] private Points _points;
    [Header("Target Markers")]
    [SerializeField] private TargetMarker[] TargetMarkers;

    public override void InstallBindings()
    {
        //Container.BindInterfacesAndSelfTo<TargetFactory>().AsSingle();
        //Container.BindInterfacesTo<LocationInstaller>().FromInstance(this);

        BindInstallerInterfaces();
        BindPoints();
        BindHero();
        BindTargetFactory();
    }

    private void Update()
    {
        Initialize();
    }

    private void BindTargetFactory()
    {
        Container
            .Bind<ITargetFactory>()
            .To<TargetFactory>()
            .AsSingle();
    }

    private void BindInstallerInterfaces()
    {
        Container
            .BindInterfacesTo<LocationInstaller>()
            .FromInstance(this)
            .AsSingle();
    }

    private void BindPoints()
    {
        Container
            .Bind<Points>()
            .FromInstance(_points)
            .AsTransient();
    }

    private void BindHero()
    {
        PlayerMovement playerMovement = Container
            .InstantiatePrefabForComponent<PlayerMovement>(_playerPrefab, _startPoint.position, Quaternion.identity,
                null);

        Container
            .Bind<PlayerMovement>()
            .FromInstance(playerMovement)
            .AsSingle();
    }

    public void Initialize()
    {
        ITargetFactory targetFactory = Container.Resolve<ITargetFactory>();

        targetFactory.Load();
        if (GameObject.FindGameObjectWithTag("Target") == null)
        {
            foreach (TargetMarker targetMarker in TargetMarkers)
            {
                targetFactory.Create(targetMarker.TargetType, targetMarker.transform.position);
            }
        }
    }
}