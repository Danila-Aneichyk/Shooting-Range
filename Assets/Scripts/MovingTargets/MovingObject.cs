using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    [Header("Initial Settings")]
    [SerializeField] public bool _needPlayOnStart = true;
    [SerializeField] private bool _isLoop = true;

    [Header("Animation Settings")]
    [SerializeField] private float _delayInPosition = 1f;
    [SerializeField] private float _duration = 1f;
    [SerializeField] private Ease _ease;

    private Tween _tween;

    public List<Transform> Points => _points;
    
    [Inject]
    public void Construct(Points points)
    {
        _points = points.PointsList;
    }
    
    private void Awake()
    {
        if (!IsValid())
            return;

        transform.position = _points.First().position;
    }

    private void Start()
    {
        if (!IsValid())
            return;

        if (_needPlayOnStart)
            Move();
    }

    public void Move()
    {
        _tween?.Kill(true);

        Sequence sequence = DOTween.Sequence(); 

        for (int i = 1; i < _points.Count; i++)
        {
            Transform point = _points[i];
            sequence.AppendInterval(_delayInPosition);
            sequence.Append(transform
                .DOMove(point.position, _duration)
                .SetEase(_ease));
        }

        sequence.AppendInterval(_delayInPosition);
        sequence.Append(transform
            .DOMove(_points.First().position, _duration)
            .SetEase(_ease));

        sequence
            .SetUpdate(UpdateType.Fixed);

        if (_isLoop)
            sequence.SetLoops(-1);

        _tween = sequence;
    }

    private bool IsValid() =>
        _points != null && _points.Count > 1;
}

