using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManpowerMenu : MonoBehaviour
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
        ManpowerStation.OnShowPeopleMenu += UpdateManpowerMenu;
    }

    private void OnDisable()
    {
        ManpowerStation.OnShowPeopleMenu -= UpdateManpowerMenu;
    }

    private void UpdateManpowerMenu(bool showMenu)
    {
        animator.SetBool("OpenMenu", showMenu);
        isOpen = showMenu;

        if (isOpen == false)
        {
            OnMenuClose();
        }
    }


    // Seriously, I could really use a job right now!!!
    public void HireMan()
    {
        if (Inventory.CheckResourceAvailable(ResourceType.FOOD, 25) && PlayerTools.ToolAvailable(ToolType.SPEAR))
        {
            Inventory.ConsumeResource(ResourceType.FOOD, 25);
            PlayerTools.ConsumeTool(ToolType.SPEAR, 1);

            ManpowerStation.lastStationUsed.SpawnMan();
        }
    }
}
