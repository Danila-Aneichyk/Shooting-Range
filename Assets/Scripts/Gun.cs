using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Values")]
    // [SerializeField] private float _damage = 10f;
    [SerializeField] private float _range = 50f;
    [SerializeField] private int _force = 10;

    [Header("Raycast")]
    [SerializeField] private Camera _camera;

    // [Header("VFXs")]
    //[SerializeField] private ParticleSystem _particleSystem;
    // [SerializeField] private Transform _shootPosition; 

    //[Header("Audio Effects")]
    //[SerializeField] private AudioClip _audioClip; 
    private void Awake()
    {
        _camera = FindObjectOfType<Camera>(); 
    }

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
            Target target = hit.transform.GetComponent<Target>();
            if (hit.collider.CompareTag("Target"))
            {
                hit.rigidbody.AddForce(transform.forward * _force);
                hit.rigidbody.useGravity = true;
            }
        }
    }
}