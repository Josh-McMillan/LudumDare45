using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureMenu : MonoBehaviour
{
    public static Action<PlannerState> OnBuildStructure;

    public static Action OnMenuClose;

    private Animator animator;

    private static bool isOpen = false;

    public static bool IsOpen
    {
        get { return isOpen; }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
            UpdateStructureMenu(isOpen);
        }
    }

    private void UpdateStructureMenu(bool showMenu)
    {
        animator.SetBool("OpenMenu", showMenu);
        isOpen = showMenu;

        if (isOpen == false)
        {
            OnMenuClose();
        }
    }

    public void BuildFarm()
    {
        UpdateStructureMenu(false);
        OnBuildStructure(PlannerState.FARM);
    }

    public void BuildCampfire()
    {
        UpdateStructureMenu(false);
        OnBuildStructure(PlannerState.CAMPFIRE);
    }

    public void BuildHut()
    {
        UpdateStructureMenu(false);
        OnBuildStructure(PlannerState.HUT);
    }
}
