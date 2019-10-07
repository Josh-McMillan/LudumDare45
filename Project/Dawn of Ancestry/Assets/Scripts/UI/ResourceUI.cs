using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] private ResourceType type;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        switch (type)
        {
            case ResourceType.PEBBLE:
                Inventory.OnPebbleUpdate += UpdateUI;
                break;

            case ResourceType.STICK:
                Inventory.OnStickUpdate += UpdateUI;
                break;

            case ResourceType.FOOD:
                Inventory.OnFoodUpdate += UpdateUI;
                break;

            case ResourceType.WOOD:
                Inventory.OnWoodUpdate += UpdateUI;
                break;

            case ResourceType.STONE:
                Inventory.OnStoneUpdate += UpdateUI;
                break;
        }
    }

    private void OnDisable()
    {
        switch (type)
        {
            case ResourceType.PEBBLE:
                Inventory.OnPebbleUpdate -= UpdateUI;
                break;

            case ResourceType.STICK:
                Inventory.OnStickUpdate -= UpdateUI;
                break;

            case ResourceType.FOOD:
                Inventory.OnFoodUpdate -= UpdateUI;
                break;

            case ResourceType.WOOD:
                Inventory.OnWoodUpdate -= UpdateUI;
                break;

            case ResourceType.STONE:
                Inventory.OnStoneUpdate -= UpdateUI;
                break;
        }
    }

    private void UpdateUI(string amount)
    {
        text.text = amount;
    }
}