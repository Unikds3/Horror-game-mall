using UnityEngine;
using TMPro;

public class ClockRadioTimer : MonoBehaviour
{
    [Header("Clock Display")]
    public TextMeshProUGUI clockText;

    [Header("Timer")]
    public float maxTime = 60f;

    private float currentTime;
    private bool timerRunning;

    [Header("Alarm")]
    public float alarmStartTime = 10f;
    public AudioSource alarmSound;
    public AudioSource tickSound;

    [Header("Monster")]
    public StationaryMonsterThreat monster;

    private bool alarmStarted;

    void Start()
    {
        currentTime = maxTime;
        UpdateClockDisplay();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartTimer();
        }

        if (!timerRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= alarmStartTime && !alarmStarted)
        {
            alarmStarted = true;

            if (alarmSound != null)
                alarmSound.Play();
        }

        if (currentTime <= 0f)
        {
            currentTime = 0f;

            StopTimer();

            if (monster != null)
                monster.TimeRanOut();
        }

        UpdateClockDisplay();
    }

    public void StartTimer()
    {
        currentTime = maxTime;
        timerRunning = true;
        alarmStarted = false;

        if (tickSound != null)
            tickSound.Play();

        UpdateClockDisplay();
    }

    public void StopTimer()
    {
        timerRunning = false;

        if (tickSound != null)
            tickSound.Stop();

        if (alarmSound != null)
            alarmSound.Stop();

        UpdateClockDisplay();
    }

    void UpdateClockDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        clockText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (currentTime <= alarmStartTime)
            clockText.color = Color.red;
        else
            clockText.color = Color.white;
    }
}