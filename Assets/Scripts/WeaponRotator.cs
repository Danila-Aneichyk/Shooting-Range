using UnityEngine;

public class WeaponRotator : MonoBehaviour
{
    [Header("Position")]
    public float amount = 0.02f;
    public float maxAmount = 0.06f;
    public float smoothAmount = 6f;

    [Header("Rotation")]
    public float rotationAmount = 4f;
    public float maxRotationAmount = 5f;
    public float smoothRotation = 12f;

    [Space]
    public bool rotationX = true;
    public bool rotationY = true;
    public bool rotationZ = true;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    private float _inputX;
    private float _inputY;
        
    private void Start()
    {
        Transform cachedTransform = transform;
        _initialPosition = cachedTransform.localPosition;
        _initialRotation = cachedTransform.localRotation;
    }
        
    private void Update()
    {
        CalculateSway();

        MoveSway();
        TiltSway();
    }

    private void CalculateSway()
    {
        _inputX = -Input.GetAxis("Mouse X");
        _inputY = -Input.GetAxis("Mouse Y");
    }

    private void MoveSway()
    {
        float moveX = Mathf.Clamp(_inputX * amount, -maxAmount, maxAmount);
        float moveY = Mathf.Clamp(_inputY * amount, -maxAmount, maxAmount);

        Vector3 finalPosition = new Vector3(moveX, moveY, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + _initialPosition, Time.deltaTime * smoothAmount);
    }

    private void TiltSway()
    {
        float tiltY = Mathf.Clamp(_inputX * rotationAmount, -maxRotationAmount, maxRotationAmount);
        float tiltX = Mathf.Clamp(_inputY * rotationAmount, -maxRotationAmount, maxRotationAmount);

        Quaternion finalRotation = Quaternion.Euler(new Vector3(rotationX ? -tiltX : 0f, rotationY ? tiltY : 0f, rotationZ ? tiltY : 0f));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation * _initialRotation, Time.deltaTime * smoothRotation);
    }
}