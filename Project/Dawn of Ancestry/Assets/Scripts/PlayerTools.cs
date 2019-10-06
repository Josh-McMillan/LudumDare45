using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolType
{
    NONE = 0,
    AXE = 1,
    SPEAR = 2,
    HAMMER = 3
}

public class PlayerTools : MonoBehaviour
{
    public static Action<string> OnAxeUpdate;
    public static Action<string> OnSpearUpdate;
    public static Action<string> OnHammerUpdate;

    public static Action<ToolType> OnToolCollect;

    private static int axes = 0;
    private static int spears = 0;
    private static int hammers = 0;

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
        switch (currentTool)
        {
            case ToolType.NONE:

                if (ToolAvailable(ToolType.AXE))
                {
                    currentTool = ToolType.AXE;
                }
                else if (ToolAvailable(ToolType.SPEAR))
                {
                    currentTool = ToolType.SPEAR;
                }
                else if (ToolAvailable(ToolType.HAMMER))
                {
                    currentTool = ToolType.HAMMER;
                }
                else
                {
                    currentTool = ToolType.NONE;
                }
                break;

            case ToolType.AXE:

                if (ToolAvailable(ToolType.SPEAR))
                {
                    currentTool = ToolType.SPEAR;
                }
                else if (ToolAvailable(ToolType.HAMMER))
                {
                    currentTool = ToolType.HAMMER;
                }
                else
                {
                    currentTool = ToolType.NONE;
                }
                break;

            case ToolType.SPEAR:

                if (ToolAvailable(ToolType.HAMMER))
                {
                    currentTool = ToolType.HAMMER;
                }
                else
                {
                    currentTool = ToolType.NONE;
                }
                break;

            case ToolType.HAMMER:

                currentTool = ToolType.NONE;
                break;

        }
    }

    public static void AddTool(ToolType type, int amount)
    {
        switch (type)
        {
            case ToolType.AXE:
                axes += amount;
                OnAxeUpdate(axes.ToString());
                OnToolCollect(ToolType.AXE);
                break;

            case ToolType.SPEAR:
                spears += amount;
                OnSpearUpdate(spears.ToString());
                OnToolCollect(ToolType.SPEAR);
                break;

            case ToolType.HAMMER:
                hammers += amount;
                OnHammerUpdate(hammers.ToString());
                OnToolCollect(ToolType.HAMMER);
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
                if (axes > 0)
                {
                    return true;
                }
                break;

            case ToolType.SPEAR:
                if (spears > 0)
                {
                    return true;
                }
                break;

            case ToolType.HAMMER:
                if (hammers > 0)
                {
                    return true;
                }
                break;

            default:
                return false;
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
