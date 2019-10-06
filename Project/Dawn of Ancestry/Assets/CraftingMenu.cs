using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenu : MonoBehaviour
{
    private Animator animator;

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
    }

    public void CraftAxe()
    {
        Debug.Log("Attempting to Craft Axe!");

        if (Inventory.CheckResourceAvailable(ResourceType.STICK, 2) && Inventory.CheckResourceAvailable(ResourceType.PEBBLE, 3))
        {
            Inventory.ConsumeResource(ResourceType.STICK, 2);
            Inventory.ConsumeResource(ResourceType.PEBBLE, 3);

            PlayerTools.AddTool(ToolType.AXE, 1);
        }
    }

    public void CraftSpear()
    {
        Debug.Log("Attempting to Craft Spear!");

        if (Inventory.CheckResourceAvailable(ResourceType.STICK, 3) && Inventory.CheckResourceAvailable(ResourceType.PEBBLE, 2))
        {
            Inventory.ConsumeResource(ResourceType.STICK, 3);
            Inventory.ConsumeResource(ResourceType.PEBBLE, 2);

            PlayerTools.AddTool(ToolType.SPEAR, 1);
        }
    }

    public void CraftHammer()
    {
        Debug.Log("Attempting to Craft Hammer!");

        if (Inventory.CheckResourceAvailable(ResourceType.STICK, 2) && Inventory.CheckResourceAvailable(ResourceType.PEBBLE, 4))
        {
            Inventory.ConsumeResource(ResourceType.STICK, 2);
            Inventory.ConsumeResource(ResourceType.PEBBLE, 4);

            PlayerTools.AddTool(ToolType.HAMMER, 1);
        }
    }
}
