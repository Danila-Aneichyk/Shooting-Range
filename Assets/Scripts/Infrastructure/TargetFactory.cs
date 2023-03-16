using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class TargetFactory : ITargetFactory
{
    private readonly DiContainer _diContainer;
    
    private Object _banditsTrioV01Prefab;
    private Object _banditsTrioV02Prefab;
    private Object _banditsTrioV03Prefab;

    private const string BanditsTrioV01 = "BanditsTrioV02";
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
    }
    
    public void Create(TargetType targetType, Vector3 targetPosition)
    {
        switch (targetType)
        {
            case TargetType.BanditsTrioV01:
                if (GameObject.FindGameObjectWithTag("Target") == null)
                {
                    _diContainer.InstantiatePrefab(_banditsTrioV01Prefab, targetPosition, Quaternion.identity, null);
                }

                break;
            case TargetType.BanditsTrioV02:
                if (GameObject.FindGameObjectWithTag("Target") == null)
                {
                    _diContainer.InstantiatePrefab(_banditsTrioV02Prefab, targetPosition, Quaternion.identity, null);
                }

                break;
            case TargetType.BanditsTrioV03:
                if (GameObject.FindGameObjectWithTag("Target") == null)
                {
                    _diContainer.InstantiatePrefab(_banditsTrioV03Prefab, targetPosition, Quaternion.identity, null);
                }

                break;
        }
    }
}