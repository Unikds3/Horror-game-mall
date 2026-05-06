using UnityEngine;

public class TypewriterClickToFocus : MonoBehaviour
{
    public TypewriterFocusController focusController;

    public void Focus()
    {
        if (focusController != null)
            focusController.EnterTypingMode();
    }
}