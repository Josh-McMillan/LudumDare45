using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    NONE,
    PEBBLE,
    STICK,
    FOOD,
    WOOD,
    STONE
}

public class Inventory : MonoBehaviour
{
    public static Action<string> OnPebbleUpdate;
    public static Action<string> OnStickUpdate;
    public static Action<string> OnFoodUpdate;
    public static Action<string> OnWoodUpdate;
    public static Action<string> OnStoneUpdate;

    private static int pebble = 0;
    private static int stick = 0;
    private static int food = 0;
    private static int wood = 0;
    private static int stone = 0;

    public static void GatherResource(ResourceType type, int amount)
    {
        switch (type)
        {
            case ResourceType.PEBBLE:
                pebble += amount;
                OnPebbleUpdate(pebble.ToString());
                break;

            case ResourceType.STICK:
                stick += amount;
                OnStickUpdate(stick.ToString());
                break;

            case ResourceType.FOOD:
                food += amount;
                OnFoodUpdate(food.ToString());
                break;

            case ResourceType.WOOD:
                wood += amount;
                OnWoodUpdate(wood.ToString());
                break;

            case ResourceType.STONE:
                stone += amount;
                OnStoneUpdate(stone.ToString());
                break;
        }
    }

    public static bool CheckResourceAvailable(ResourceType type, int amount)
    {
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
