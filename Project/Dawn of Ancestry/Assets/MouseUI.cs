using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUI : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Resource.OnShowTip += ShowMouse;
    }

    private void OnDisable()
    {
        Resource.OnShowTip -= ShowMouse;
    }

    private void ShowMouse(bool show)
    {
        animator.SetBool("Show Mouse", show);
    }
}
