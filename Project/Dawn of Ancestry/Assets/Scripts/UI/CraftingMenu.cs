using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenu : MonoBehaviour
{
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

    private void OnEnable()
    {
        CraftingStation.OnShowCraftingMenu += UpdateCraftingMenu;
    }

    private void OnDisable()
    {
        CraftingStation.OnShowCraftingMenu -= UpdateCraftingMenu;
    }

    private void UpdateCraftingMenu(bool showMenu)
    {
        animator.SetBool("OpenMenu", showMenu);
        isOpen = showMenu;

        if (isOpen == false)
        {
            OnMenuClose();
        }
    }

    public void CraftAxe()
    {
        if (Inventory.CheckResourceAvailable(ResourceType.STICK, 2) && Inventory.CheckResourceAvailable(ResourceType.PEBBLE, 3))
        {
            Inventory.ConsumeResource(ResourceType.STICK, 2);
            Inventory.ConsumeResource(ResourceType.PEBBLE, 3);

            PlayerTools.AddTool(ToolType.AXE, 1);
        }
    }

    public void CraftSpear()
    {
        if (Inventory.CheckResourceAvailable(ResourceType.STICK, 3) && Inventory.CheckResourceAvailable(ResourceType.PEBBLE, 2))
        {
            Inventory.ConsumeResource(ResourceType.STICK, 3);
            Inventory.ConsumeResource(ResourceType.PEBBLE, 2);

            PlayerTools.AddTool(ToolType.SPEAR, 1);
        }
    }

    public void CraftHammer()
    {
        if (Inventory.CheckResourceAvailable(ResourceType.STICK, 2) && Inventory.CheckResourceAvailable(ResourceType.PEBBLE, 4))
        {
            Inventory.ConsumeResource(ResourceType.STICK, 2);
            Inventory.ConsumeResource(ResourceType.PEBBLE, 4);

            PlayerTools.AddTool(ToolType.HAMMER, 1);
        }
    }
}
