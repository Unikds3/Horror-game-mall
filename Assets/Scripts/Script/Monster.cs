using UnityEngine;

public class StationaryMonsterThreat : MonoBehaviour
{
    public Transform[] stagePositions;

    public int aggro = 0;
    public int maxAggro = 5;

    private int lastAggro = -1;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip moveSound;
    public AudioClip killSound;
    public AudioClip breathingSound;

    void Start()
    {
        MoveToStage(aggro);
    }

    void Update()
    {
        if (aggro != lastAggro)
        {
            MoveToStage(aggro);
        }

      
    }

    public void WrongAnswer()
    {
        aggro += 1;
        aggro = Mathf.Clamp(aggro, 0, maxAggro);

        if (audioSource != null && moveSound != null)
            audioSource.PlayOneShot(moveSound);

        MoveToStage(aggro);
    }

    public void TimeRanOut()
    {
        aggro = maxAggro;

        if (audioSource != null && killSound != null)
            audioSource.PlayOneShot(killSound);

        MoveToStage(aggro);
    }

    public void RepeatButtonUsed()
    {
        aggro += 1;
        aggro = Mathf.Clamp(aggro, 0, maxAggro);

        if (audioSource != null && breathingSound != null)
            audioSource.PlayOneShot(breathingSound);

        MoveToStage(aggro);
    }

    public void CorrectAnswer()
    {
        aggro -= 1;
        aggro = Mathf.Clamp(aggro, 0, maxAggro);

        MoveToStage(aggro);
    }

    void MoveToStage(int stage)
    {
        if (stagePositions == null || stagePositions.Length == 0) return;

        int index = Mathf.Clamp(stage, 0, stagePositions.Length - 1);

        transform.position = stagePositions[index].position;
        transform.rotation = stagePositions[index].rotation;

        lastAggro = aggro;

        Debug.Log("Monster moved to stage: " + index);
    }
}