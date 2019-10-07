using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNear : MonoBehaviour
{
    private bool playerNear = false;

    public bool IsNear
    {
        get { return playerNear; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerNear = false;
        }
    }
}
