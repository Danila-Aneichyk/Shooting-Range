using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    public List<Transform> PointsList => _points;
}