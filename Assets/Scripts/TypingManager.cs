using UnityEngine;
using System.Collections.Generic;

public class TypingManager : MonoBehaviour
{
    // This manager is in the keys so their animation can interract with it if needed
    [SerializeField] private TypingManagerArgs args;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        animator.SetTrigger("IsPushed");

        int i = args.keys.IndexOf(gameObject);

        if (i < args.currentKeyboardLayout.Length) // is key valid
        {
            if (args.currentKeyboardLayout[i] == args.currentString[0])
            {
                // right letter
                // // correct, sound? // might get overwhelming

                args.currentString = args.currentString.Substring(1);

                if (args.currentString.Length <= 0)
                {
                    // do something?
                    args.GetNewString();
                }
            }
            else
            {
                // wrong letter
                args.ShouldInterruptEnonciation = true;
                // // punishment sound
                // // punishment

                StartCoroutine(args.EnunciateString());
            }
        }
    }
}
