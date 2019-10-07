using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    private Animator animator;

    private bool showHelp = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            showHelp = !showHelp;
            animator.SetBool("ShowHelp", showHelp);
        }
    }
}
