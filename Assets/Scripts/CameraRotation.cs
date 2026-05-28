using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float sensitivity = 30f;
    [SerializeField] private float minPitch = -60f;
    [SerializeField] private float maxPitch = 70f;

    private float yaw;
    private float pitch;
    private Vector2 input;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = playerBody.eulerAngles.y;
        pitch = cameraTransform.localEulerAngles.x;
    }

    void Update()
    {
        Rotate();
    }

    public void OnRotation(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    private void Rotate()
    {
        yaw += input.x * sensitivity * Time.deltaTime;
        pitch -= input.y * sensitivity * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Horizontal → Player
        playerBody.rotation = Quaternion.Euler(0f, yaw, 0f);

        // Vertical → Camera
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}