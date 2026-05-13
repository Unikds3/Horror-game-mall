using UnityEngine;

public class SeatedLookController : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 80f;

    public bool canLook = true;

    private float rotationX;
    private float rotationY;

    void Start()
    {
        SyncRotationToCurrentTransform();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!canLook) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -maxLookAngle, maxLookAngle);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
    public void ResetLook()
    {
        rotationX = 0f;
        rotationY = 0f;
        transform.localRotation = Quaternion.identity;
    }

    public void SyncRotationToCurrentTransform()
    {
        Vector3 angles = transform.localEulerAngles;

        rotationX = angles.x;
        rotationY = angles.y;

        if (rotationX > 180f)
            rotationX -= 360f;

        if (rotationY > 180f)
            rotationY -= 360f;
    }
}