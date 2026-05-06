using UnityEngine;

public class ClickableTypewriterKey : MonoBehaviour
{
    public enum KeyType
    {
        Letter,
        Space,
        Backspace,
        Enter
    }

    public KeyType keyType;
    public char letter;
    public TypewriterInputManager inputManager;

    public float pressDepth = 0.03f;
    public float pressSpeed = 12f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void OnMouseDown()
    {
        Press();
    }

    public void Press()
    {
        if (inputManager == null) return;

        if (keyType == KeyType.Letter)
            inputManager.TypeLetter(letter);

        if (keyType == KeyType.Space)
            inputManager.PressSpace();

        if (keyType == KeyType.Backspace)
            inputManager.PressBackspace();

        if (keyType == KeyType.Enter)
            inputManager.PressEnter();

        StopAllCoroutines();
        StartCoroutine(PressAnimation());
    }

    System.Collections.IEnumerator PressAnimation()
    {
        Vector3 downPos = startPos + Vector3.down * pressDepth;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * pressSpeed;
            transform.localPosition = Vector3.Lerp(startPos, downPos, t);
            yield return null;
        }

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * pressSpeed;
            transform.localPosition = Vector3.Lerp(downPos, startPos, t);
            yield return null;
        }
    }
}