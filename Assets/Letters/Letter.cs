using UnityEngine;

[CreateAssetMenu(fileName = "Letter", menuName = "Scriptable Objects/Letter")]
public class Letter : ScriptableObject
{
    [SerializeField] private char id;
    [SerializeField] private AudioClip normalSound;
    [SerializeField] private AudioClip monsterSound;

    public char ID { get { return id; } }
    public AudioClip NormalSound { get { return normalSound; } }
    public AudioClip MonsterSound { get { return monsterSound; } }
}
