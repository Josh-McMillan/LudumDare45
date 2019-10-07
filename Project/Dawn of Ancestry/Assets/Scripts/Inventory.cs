using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    NONE = 0,
    PEBBLE = 1,
    STICK = 2,
    FOOD = 3,
    WOOD = 4,
    STONE = 5
}

public class Inventory : MonoBehaviour
{
    private static bool debugInfiniteInventory = true;

    public static Action<string> OnPebbleUpdate;
    public static Action<string> OnStickUpdate;
    public static Action<string> OnFoodUpdate;
    public static Action<string> OnWoodUpdate;
    public static Action<string> OnStoneUpdate;

    public static Action<ResourceType> OnItemGather;

    private static int pebble = 0;
    private static int stick = 0;
    private static int food = 0;
    private static int wood = 0;
    private static int stone = 0;

    private void Start()
    {
        if (debugInfiniteInventory)
        {
            Debug.LogWarning("DEBUG: INFINITE INVENTORY ACTIVATED");
        }
    }

    public static void GatherResource(ResourceType type, int amount)
    {
        switch (type)
        {
            case ResourceType.PEBBLE:
                pebble += amount;
                OnPebbleUpdate(pebble.ToString());
                OnItemGather(ResourceType.PEBBLE);
                break;

            case ResourceType.STICK:
                stick += amount;
                OnStickUpdate(stick.ToString());
                OnItemGather(ResourceType.STICK);
                break;

            case ResourceType.FOOD:
                food += amount;
                OnFoodUpdate(food.ToString());
                OnItemGather(ResourceType.FOOD);
                break;

            case ResourceType.WOOD:
                wood += amount;
                OnWoodUpdate(wood.ToString());
                OnItemGather(ResourceType.WOOD);
                break;

            case ResourceType.STONE:
                stone += amount;
                OnStoneUpdate(stone.ToString());
                OnItemGather(ResourceType.STONE);
                break;
        }
    }

    public static bool CheckResourceAvailable(ResourceType type, int amount)
    {
        if (debugInfiniteInventory)
        {
            return true;
        }

        switch (type)
        {
            case ResourceType.PEBBLE:
                if (pebble >= amount)
                {
                    return true;
                }
                break;

            case ResourceType.STICK:
                if (stick >= amount)
                {
                    return true;
                }
                break;

            case ResourceType.FOOD:
                if (food >= amount)
                {
                    return true;
                }
                break;

            case ResourceType.WOOD:
                if (wood >= amount)
                {
                    return true;
                }
                break;

            case ResourceType.STONE:
                if (stone >= amount)
                {
                    return true;
                }
                break;
        }

        return false;
    }

    public static void ConsumeResource(ResourceType type, int amount)
    {
        if (debugInfiniteInventory)
        {
            return;
        }

        switch (type)
        {
            case ResourceType.PEBBLE:
                pebble -= amount;

                if (pebble < 0)
                {
                    pebble = 0;
                }

                OnPebbleUpdate(pebble.ToString());

                break;

            case ResourceType.STICK:
                stick -= amount;

                if (stick < 0)
                {
                    stick = 0;
                }

                OnStickUpdate(stick.ToString());

                break;

            case ResourceType.FOOD:
                food -= amount;

                if (food < 0)
                {
                    food = 0;
                }

                OnFoodUpdate(food.ToString());

                break;

            case ResourceType.WOOD:
                stone -= amount;

                if (stone < 0)
                {
                    stone = 0;
                }

                OnWoodUpdate(wood.ToString());

                break;

            case ResourceType.STONE:
                stone -= amount;

                if (stone < 0)
                {
                    stone = 0;
                }

                OnStoneUpdate(stone.ToString());

                break;
        }
    }
}
