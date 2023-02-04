using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity = 10f;
        [SerializeField] private Transform _playerBody;

        private float _xAxis = 0f;

        private void Start()
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true; 
        }

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

            _xAxis -= mouseY;
            _xAxis = Mathf.Clamp(_xAxis, -90f, 90f); 
            
            transform.localRotation = Quaternion.Euler(_xAxis, 0f, 0f);
            _playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}