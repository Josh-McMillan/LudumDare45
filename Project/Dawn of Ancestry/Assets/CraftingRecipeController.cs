using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipeController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        CraftingMenu.OnMenuClose += CloseRecipe;
    }

    private void OnDisable()
    {
        CraftingMenu.OnMenuClose -= CloseRecipe;
    }

    public void OpenRecipe()
    {
        if (CraftingMenu.IsOpen)
        {
            animator.SetBool("OpenRecipe", true);
        }
    }

    public void CloseRecipe()
    {
        animator.SetBool("OpenRecipe", false);
    }
}
