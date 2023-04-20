using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class TargetFactory : ITargetFactory
{
    private readonly DiContainer _diContainer;
    
    private Object _banditsTrioV01Prefab;
    private Object _banditsTrioV02Prefab;
    private Object _banditsTrioV03Prefab;
    
    private Object[] _targetPrefabs;

    private const string BanditsTrioV01 = "BanditsTrioV01";
    private const string BanditsTrioV02 = "BanditsTrioV02";
    private const string BanditsTrioV03 = "BanditsTrioV03";

    public TargetFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public void Load()
    {
        _banditsTrioV01Prefab = Resources.Load(BanditsTrioV01) as GameObject;
        _banditsTrioV02Prefab = Resources.Load(BanditsTrioV02) as GameObject;
        _banditsTrioV03Prefab = Resources.Load(BanditsTrioV03) as GameObject;
        _targetPrefabs = new Object[]
        {
            _banditsTrioV01Prefab,
            _banditsTrioV02Prefab,
            _banditsTrioV03Prefab
        };
    }

    public void Create(TargetType targetType, Vector3 targetPosition)
    {
        if (GameObject.FindGameObjectWithTag("Target") == null)
        {
            Object targetPrefab = _targetPrefabs[Random.Range(0, _targetPrefabs.Length)];
            _diContainer.InstantiatePrefab(targetPrefab, targetPosition, Quaternion.identity, null);
        }
    }
}