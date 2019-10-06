using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    public static Action<bool> OnShowCraftingMenu;

    private bool playerNear = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerNear = true;
        }

        OnShowCraftingMenu(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerNear = false;
        }

        OnShowCraftingMenu(false);
    }
}
