using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceType resource;

    [SerializeField] private float collectionTime = 2.0f;

    private bool playerNear = false;

    private bool canCollect = true;

    private WaitForSeconds waitTime;

    private void Start()
    {
        waitTime = new WaitForSeconds(collectionTime);
    }

    private void Update()
    {
        if (playerNear)
        {
            if (Input.GetMouseButton(0) && canCollect)
            {
                Debug.Log("Player is collecting resource!");
                StartCoroutine(CollectResource());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player is near resource!");
        playerNear = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player has left resource!");
        playerNear = false;
    }

    IEnumerator CollectResource()
    {
        canCollect = false;
        Inventory.GatherResource(resource, 1);

        yield return waitTime;

        canCollect = true;
    }
}
