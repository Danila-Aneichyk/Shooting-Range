using System;
using UnityEngine;

public class TargetHp : MonoBehaviour, IHealth
{
    [Header("HP Values")]
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private int _startHp = 100;
    
    public event Action<int> OnChanged;
    public int CurrentHp { get; set; }

    public int MaxHp => _maxHp;
    
    private void Awake()
    {
        CurrentHp = _startHp;
        OnChanged?.Invoke(CurrentHp);
    }
    
    public void ApplyDamage(int damage)
    {
        CurrentHp = Mathf.Max(0, CurrentHp - damage);
        OnChanged?.Invoke(CurrentHp);
    }
}
