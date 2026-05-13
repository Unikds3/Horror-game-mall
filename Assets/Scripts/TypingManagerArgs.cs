using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TypingManagerArgs : MonoBehaviour
{
    // This object was made so I  don't have to serialize over 40 things in each instance of the TypingManager
    public AudioSource radio;

    public List<GameObject> keys;
    public List<Letter> letters;

    public static string validLetters = "";
    public static Dictionary<char, Letter> letterDict = new Dictionary<char, Letter>();

    [System.NonSerialized] public string currentKeyboardLayout;
    [System.NonSerialized] public string currentString;
    
    private bool shouldInterruptEnonciation = false;
    private bool enunciating = false;

    private void Awake()
    { 
        foreach (Letter letter in letters)
        {
            validLetters += letter.ID;
            letterDict.Add(letter.ID, letter);
        }

        currentKeyboardLayout = validLetters;

        EmptyKeyboard();
        ShuffleKeyboard();
        GetNewString();
    }

    public void EmptyKeyboard()
    {
        foreach (GameObject key in keys)
        {
            key.transform.Find("Canvas").Find("Letter").GetComponent<TMP_Text>().text = "";
        }
    }

    public void ShuffleKeyboard()
    {
        currentKeyboardLayout = string.Join("", new HashSet<char>(currentKeyboardLayout));

        // the following relies on the fact keys.Count >= letter.Count
        for (int i = 0; i < currentKeyboardLayout.Length; ++i)
        {
            keys[i].transform.Find("Canvas").Find("Letter").GetComponent<TMP_Text>().text = currentKeyboardLayout[i].ToString();
        }
    }

    public void GetNewString()
    {
        // returns 5-8 random chars
        currentString = string.Join("", new HashSet<char>(validLetters)).Substring(0, Random.Range(1, 5) + 4);

        StartCoroutine(EnunciateString());
    }

    public IEnumerator EnunciateString()
    {
        enunciating = true;

        for (int i = 0; i < currentString.Length; ++i)
        { 
            if (shouldInterruptEnonciation)
            {
                shouldInterruptEnonciation = false;
                break;
            }

            radio.clip = letterDict[currentString[i]].NormalSound;
            radio.Play();
            yield return new WaitForSeconds(letterDict[currentString[i]].NormalSound.length);
        }

        enunciating = false;
    }

    public bool ShouldInterruptEnonciation { 
        get 
        { 
            return shouldInterruptEnonciation; 
        } 
        set 
        {
            if (enunciating)
            {
                shouldInterruptEnonciation = value;
            }
        } 
    }
}
