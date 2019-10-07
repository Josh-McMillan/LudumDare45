using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureRecipeController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StructureMenu.OnMenuClose += CloseRecipe;
    }

    private void OnDisable()
    {
        StructureMenu.OnMenuClose -= CloseRecipe;
    }

    public void OpenRecipe()
    {
        if (StructureMenu.IsOpen)
        {
            animator.SetBool("OpenRecipe", true);
        }
    }

    public void CloseRecipe()
    {
        animator.SetBool("OpenRecipe", false);
    }
}
