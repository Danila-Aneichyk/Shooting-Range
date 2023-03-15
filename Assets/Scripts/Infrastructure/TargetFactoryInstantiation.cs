using UnityEngine;

public class TargetFactoryInstantiation : MonoBehaviour
{
    [Header("Target Factory")]
    private ITargetFactory _targetFactory;
    [SerializeField] private TargetMarker[] TargetMarkers;

    public void Start()
    {
        /*_targetFactory = GetComponent<ITargetFactory>();
        _targetFactory.Load();*/
    }

    private void Update()
    {
        _targetFactory = GetComponent<ITargetFactory>();
        _targetFactory.Load();
        
            foreach (TargetMarker targetMarker in TargetMarkers)
            {
                _targetFactory.Create(targetMarker.TargetType, targetMarker.transform.position);
            }
        
       
    }
}