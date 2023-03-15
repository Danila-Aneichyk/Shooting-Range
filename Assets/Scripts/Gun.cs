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
        int randomDamage = Random.Range(30,100);
        
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range))
        {
            if (!hit.transform.CompareTag("Target"))
                return;

            ApplyHit(hit, randomDamage);
        }
    }

    private void ApplyHit(RaycastHit hit, int randomDamage)
    {
        Debug.Log(hit.transform.name);
        TargetHp targetHp = hit.transform.GetComponent<TargetHp>();
        targetHp.CurrentHp -= randomDamage;
        Debug.Log($"Current damage is: {randomDamage}");
        if (hit.collider.CompareTag("Target") && targetHp.CurrentHp <= 0)
        {
            hit.rigidbody.AddForce(transform.forward * _force);
            hit.rigidbody.useGravity = true;
            
        }
    }
}