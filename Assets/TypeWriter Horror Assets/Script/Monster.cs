using UnityEngine;

public class MonsterThreat : MonoBehaviour
{
    public int dangerLevel = 0;
    public int maxDanger = 5;

    public void TimeRanOut()
    {
        dangerLevel += 2;
        Debug.Log("Monster got closer. Danger: " + dangerLevel);

        if (dangerLevel >= maxDanger)
        {
            Debug.Log("Player dead.");
        }
    }

    public void WrongAnswer()
    {
        dangerLevel += 1;
    }

    public void CorrectAnswer()
    {
        dangerLevel = Mathf.Max(0, dangerLevel - 1);
    }
}