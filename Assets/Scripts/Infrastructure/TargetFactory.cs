using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class TargetFactory : ITargetFactory
{
    private readonly DiContainer _diContainer; 
    
    private Object _manWithAGunPrefab;
    private Object _manWithABatPrefab;
    private Object _manWithAKnifePrefab;
    
    private const string ManWithAGun = "ManWithAGun";
    private const string ManWithABat = "ManWithABat";
    private const string ManWithAKnife = "ManWithAKnife";                                                                                                                                                                                  

    public TargetFactory(DiContainer diContainer)
    {
        _diContainer = diContainer; 
    }
    
    public void Load()
    {
        _manWithAGunPrefab = Resources.Load(ManWithAGun) as GameObject;
        _manWithABatPrefab = Resources.Load(ManWithABat) as GameObject;
        _manWithAKnifePrefab = Resources.Load(ManWithAKnife) as GameObject;
    }
        
    public void Create(TargetType targetType, Vector3 targetPosition)
    {
        switch (targetType)
        {
            case TargetType.ManWithABat:
                _diContainer.InstantiatePrefab(_manWithABatPrefab, targetPosition, Quaternion.identity, null);
                break;
            case TargetType.ManWithAGun:
                _diContainer.InstantiatePrefab(_manWithAGunPrefab, targetPosition, Quaternion.identity, null);
                break;
            case TargetType.ManWithAKnife:
                _diContainer.InstantiatePrefab(_manWithAKnifePrefab, targetPosition, Quaternion.identity, null);
                break;
        }
    }
}