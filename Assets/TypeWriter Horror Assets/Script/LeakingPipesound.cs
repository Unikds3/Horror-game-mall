using UnityEngine;
using System.Collections;

public class LeakingPipeSound : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource leakAudio;

    [Header("Timing")]
    public float minPlayTime = 5f;
    public float maxPlayTime = 15f;

    public float minSilentTime = 2f;
    public float maxSilentTime = 6f;

    void Start()
    {
        StartCoroutine(LeakRoutine());
    }

    IEnumerator LeakRoutine()
    {
        while (true)
        {
           
            leakAudio.Play();

            float playTime = Random.Range(minPlayTime, maxPlayTime);
            yield return new WaitForSeconds(playTime);

           
            leakAudio.Stop();

            float silentTime = Random.Range(minSilentTime, maxSilentTime);
            yield return new WaitForSeconds(silentTime);
        }
    }
}