using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponRotator : MonoBehaviour
    {
        [Header("Position")]
        public float amount = 0.02f;
        public float maxAmonut = 0.06f;
        public float smoothAmount = 6f;

        [Header("Rotation")]
        public float rotationAmount = 4f;
        public float maxRotationAmount = 5f;
        public float smoothRotation = 12f;

        [Space]
        public bool rotationX = true;
        public bool rotationY = true;
        public bool rotationZ = true;

        private Vector3 initialPosition;
        private Quaternion initialRotation;

        private float InputX;
        private float InputY;
        
        private void Start()
        {
            initialPosition = transform.localPosition;
            initialRotation = transform.localRotation;
        }
        
        private void Update()
        {
            CalculateSway();

            MoveSway();
            TiltSway();
        }

        private void CalculateSway()
        {
            InputX = -Input.GetAxis("Mouse X");
            InputY = -Input.GetAxis("Mouse Y");
        }

        private void MoveSway()
        {
            float moveX = Mathf.Clamp(InputX * amount, -maxAmonut, maxAmonut);
            float moveY = Mathf.Clamp(InputY * amount, -maxAmonut, maxAmonut);

            Vector3 finalPosition = new Vector3(moveX, moveY, 0);

            transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);
        }

        private void TiltSway()
        {
            float tiltY = Mathf.Clamp(InputX * rotationAmount, -maxRotationAmount, maxRotationAmount);
            float tiltX = Mathf.Clamp(InputY * rotationAmount, -maxRotationAmount, maxRotationAmount);

            Quaternion finalRotation = Quaternion.Euler(new Vector3(rotationX ? -tiltX : 0f, rotationY ? tiltY : 0f, rotationZ ? tiltY : 0f));

            transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation * initialRotation, Time.deltaTime * smoothRotation);
        }
    }
}