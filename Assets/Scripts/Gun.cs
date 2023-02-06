using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _range = 50f;

    [Header("Raycast")]
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
