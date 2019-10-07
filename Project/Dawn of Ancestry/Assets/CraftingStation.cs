using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    public static Action<bool> OnShowCraftingMenu;

    [SerializeField] private Construction construction;

    private void OnEnable()
    {
        Construction.OnConstructionComplete += ShowMenu;
    }

    private void OnDisable()
    {
        Construction.OnConstructionComplete -= ShowMenu;
    }

    private void ShowMenu(GameObject construction)
    {
        if (construction == transform.parent.gameObject)
        {
            OnShowCraftingMenu(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (construction.IsBuilt)
        {
            OnShowCraftingMenu(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (construction.IsBuilt)
        {
            OnShowCraftingMenu(false);
        }
    }
}
