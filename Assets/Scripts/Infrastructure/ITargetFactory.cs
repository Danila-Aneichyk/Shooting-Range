using UnityEngine;

public interface ITargetFactory
{
    public void Load();
    public void Create(TargetType targetType, Vector3 targetPosition); 
}