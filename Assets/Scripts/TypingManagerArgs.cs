using UnityEngine;
using System.Collections.Generic;

public class TypingManagerArgs : MonoBehaviour
{
    // This object was made so I  don't have to serialize over 40 things in each instance of the TypingManager
    public List<GameObject> keys;
    public List<Letter> letters;
}
