using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolType
{
    NONE,
    AXE,
    SPEAR,
    HAMMER
}

public class PlayerTools : MonoBehaviour
{
    public static Action<string> OnAxeUpdate;
    public static Action<string> OnSpearUpdate;
    public static Action<string> OnHammerUpdate;

    private static int axes = 1;
    private static int spears = 1;
    private static int hammers = 1;

    private static ToolType currentTool = ToolType.NONE;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SwitchTool();
        }
    }

    public static ToolType GetCurrentTool()
    {
        return currentTool;
    }

    public static int GetCurrentToolInt()
    {
        return (int)currentTool;
    }

    public void SwitchTool()
    {
        NextTool();
        animator.SetInteger("ToolType", (int)currentTool);
    }

    public static void NextTool()
    {
        if ((int)currentTool == 3)
        {
            currentTool = 0;
        }
        else
        {
            currentTool++;
        }

        if (!ToolAvailable(currentTool))
        {
            NextTool();
        }
    }

    public static void AddTool(ToolType type, int amount)
    {
        switch (type)
        {
            case ToolType.AXE:
                axes += amount;
                OnAxeUpdate(axes.ToString());
                break;

            case ToolType.SPEAR:
                spears += amount;
                OnSpearUpdate(spears.ToString());
                break;

            case ToolType.HAMMER:
                hammers += amount;
                OnHammerUpdate(hammers.ToString());
                break;
        }
    }

    public static bool ToolAvailable(ToolType type)
    {
        switch (type)
        {
            case ToolType.NONE:
                return true;

            case ToolType.AXE:
                if (axes >= 0)
                {
                    return true;
                }
                break;

            case ToolType.SPEAR:
                if (spears >= 0)
                {
                    return true;
                }
                break;

            case ToolType.HAMMER:
                if (hammers >= 0)
                {
                    return true;
                }
                break;
        }

        return false;
    }

    public static void ConsumeTool(ToolType type, int amount)
    {
        switch (type)
        {
            case ToolType.AXE:
                axes -= amount;

                if (axes < 0)
                {
                    axes = 0;
                }

                OnAxeUpdate(axes.ToString());

                break;

            case ToolType.SPEAR:
                spears -= amount;

                if (spears < 0)
                {
                    spears = 0;
                }

                OnSpearUpdate(spears.ToString());

                break;

            case ToolType.HAMMER:
                hammers -= amount;

                if (hammers < 0)
                {
                    hammers = 0;
                }

                OnHammerUpdate(hammers.ToString());

                break;
        }
    }
}
