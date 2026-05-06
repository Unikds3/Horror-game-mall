using UnityEngine;

public class TypewriterAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip keySound;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            audioSource.PlayOneShot(keySound);
        }
    }
}