using UnityEngine;

public class SeatedLook360 : MonoBehaviour
{
    [Header("Camera")]
    public Transform playerCamera;

    [Header("Settings")]
    public float mouseSensitivity = 2f;
    public float smoothSpeed = 8f;

    [Header("Vertical Limits")]
    public float upLimit = 25f;
    public float downLimit = -25f;

    private float targetYaw;
    private float targetPitch;

    private float currentYaw;
    private float currentPitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerCamera == null)
            playerCamera = Camera.main.transform;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        
        targetYaw += mouseX;

       
        targetPitch -= mouseY;
        targetPitch = Mathf.Clamp(targetPitch, downLimit, upLimit);

        currentYaw = Mathf.Lerp(currentYaw, targetYaw, Time.deltaTime * smoothSpeed);
        currentPitch = Mathf.Lerp(currentPitch, targetPitch, Time.deltaTime * smoothSpeed);

        playerCamera.localRotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
    }
}