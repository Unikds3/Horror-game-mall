using UnityEngine;

public class TypewriterFocusController : MonoBehaviour
{
    public Transform playerCamera;
    public Transform typingCameraPoint;
    public TypewriterInputManager inputManager;

    public float moveSpeed = 6f;
    public KeyCode exitKey = KeyCode.Escape;

    private bool typingMode;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Update()
    {
        if (typingMode)
        {
            playerCamera.position = Vector3.Lerp(playerCamera.position, typingCameraPoint.position, Time.deltaTime * moveSpeed);
            playerCamera.rotation = Quaternion.Lerp(playerCamera.rotation, typingCameraPoint.rotation, Time.deltaTime * moveSpeed);

            if (Input.GetKeyDown(exitKey))
                ExitTypingMode();
        }
    }

    public void EnterTypingMode()
    {
        originalPosition = playerCamera.position;
        originalRotation = playerCamera.rotation;

        typingMode = true;

        if (inputManager != null)
            inputManager.SetTextVisible(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ExitTypingMode()
    {
        typingMode = false;

        playerCamera.position = originalPosition;
        playerCamera.rotation = originalRotation;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}