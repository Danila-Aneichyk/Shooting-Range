using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveVector = transform.right * horizontal + transform.forward * vertical;
        Vector3 position = transform.position; 
        position += moveVector * (_speed * Time.deltaTime);
        transform.position = position; 
    }
}
