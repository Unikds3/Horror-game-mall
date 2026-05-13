using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class TypingManagerArgs : MonoBehaviour
{
    // This object was made so I  don't have to serialize over 40 things in each instance of the TypingManager
    public List<GameObject> keys;
    public List<Letter> letters;

    public static string VALID_LETTERS = "QWERTYUIOPASDFGHJKLZXCVBNM";
    public static Dictionary<char, Letter> letterDict = new Dictionary<char, Letter>();

    [System.NonSerialized] public string currentKeyboardLayout;
    [System.NonSerialized] public string currentString;

    private void Awake()
    { 
        currentKeyboardLayout = VALID_LETTERS;

        foreach (Letter letter in letters)
        { 
            letterDict.Add(letter.ID, letter);
        }

        EmptyKeyboard();
        ShuffleKeyboard();
        GetNewString();
    }

    public void EmptyKeyboard()
    {
        foreach (GameObject key in keys)
        {
            key.GetComponent<TMP_Text>().text = "";
        }
    }

    public void ShuffleKeyboard()
    {
        currentKeyboardLayout = string.Join("", new HashSet<char>(currentKeyboardLayout));

        // the following relies on the fact keys.Count >= letter.Count
        for (int i = 0; i < currentKeyboardLayout.Length; ++i)
        {
            keys[i].GetComponent<TMP_Text>().text = currentKeyboardLayout[i].ToString();
        }
    }

    public void GetNewString()
    {
        // returns 5-8 random chars
        currentString = string.Join("", new HashSet<char>(VALID_LETTERS)).Substring(0, Random.Range(1, 5) + 4);

        // enunciate string
    }
}
