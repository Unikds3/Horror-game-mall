using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterInputManager : MonoBehaviour
{
    public TextMeshProUGUI typedText;
    public CanvasGroup textFadeGroup;
    public AudioSource audioSource;
    public AudioClip keyClickSound;

    public float fadeDelay = 2f;
    public float fadeSpeed = 2f;

    private string currentInput = "";
    private Coroutine fadeRoutine;

    void Start()
    {
        UpdateText();
        SetTextVisible(false);
    }

    public void TypeLetter(char letter)
    {
        currentInput += letter;
        UpdateText();
        PlaySound();
        ShowTextThenFade();
    }

    public void PressSpace()
    {
        currentInput += " ";
        UpdateText();
        PlaySound();
        ShowTextThenFade();
    }

    public void PressBackspace()
    {
        if (currentInput.Length > 0)
            currentInput = currentInput.Substring(0, currentInput.Length - 1);

        UpdateText();
        PlaySound();
        ShowTextThenFade();
    }

    public void PressEnter()
    {
        Debug.Log("Submitted: " + currentInput);
        PlaySound();
        ShowTextThenFade();
    }

    void UpdateText()
    {
        if (typedText != null)
            typedText.text = currentInput;
    }

    void PlaySound()
    {
        if (audioSource != null && keyClickSound != null)
            audioSource.PlayOneShot(keyClickSound);
    }

    void ShowTextThenFade()
    {
        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);

        fadeRoutine = StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        SetTextVisible(true);

        yield return new WaitForSeconds(fadeDelay);

        while (textFadeGroup.alpha > 0f)
        {
            textFadeGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        textFadeGroup.alpha = 0f;
    }

    public void SetTextVisible(bool visible)
    {
        if (textFadeGroup == null) return;

        textFadeGroup.alpha = visible ? 1f : 0f;
    }
}