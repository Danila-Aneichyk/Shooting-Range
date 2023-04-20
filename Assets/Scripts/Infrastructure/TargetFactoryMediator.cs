using System;
using UnityEngine;
using Zenject;

public class TargetFactoryMediator : MonoBehaviour
{
    [Header("Target Factory")]
    private ITargetFactory _targetFactory;
    [SerializeField] private TargetMarker[] TargetMarkers;

    [Inject]
    private void Construct(ITargetFactory targetFactory)
    {
        _targetFactory = targetFactory; 
    }

    public void Start()
    {
        _targetFactory.Load();
    }

    private void Update()
    {
        TargetCreating();
    }

    private void TargetCreating()
    {
        foreach (TargetMarker targetMarker in TargetMarkers)
        {
                _targetFactory.Create(targetMarker.TargetType, targetMarker.transform.position);
        }
    }
}