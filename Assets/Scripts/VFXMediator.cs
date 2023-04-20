using UnityEngine;

public class VFXMediator : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] private GameObject _vfxPrefab;
    [SerializeField] private Transform _mainObject;
    [SerializeField] private GameObject _rotationRepeat;
    private Transform _rot;
    
    public void SpawnVFX(Transform shootPosition)
    {
        if (_vfxPrefab == null)
            return;
        Instantiate(_vfxPrefab, shootPosition.position, shootPosition.rotation); ;

    }
}