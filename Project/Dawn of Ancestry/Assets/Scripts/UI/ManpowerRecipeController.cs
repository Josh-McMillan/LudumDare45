using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManpowerRecipeController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ManpowerMenu.OnMenuClose += CloseRecipe;
    }

    private void OnDisable()
    {
        ManpowerMenu.OnMenuClose -= CloseRecipe;
    }

    public void OpenRecipe()
    {
        if (ManpowerMenu.IsOpen)
        {
            animator.SetBool("OpenRecipe", true);
        }
    }

    public void CloseRecipe()
    {
        animator.SetBool("OpenRecipe", false);
    }
}
