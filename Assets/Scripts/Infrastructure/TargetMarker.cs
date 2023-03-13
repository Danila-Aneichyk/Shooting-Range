using UnityEngine;

public class TargetMarker : MonoBehaviour
{
    public TargetType TargetType;
    private float _radius = 0.1f; 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _radius);
        Gizmos.color = Color.white;        
    }
}