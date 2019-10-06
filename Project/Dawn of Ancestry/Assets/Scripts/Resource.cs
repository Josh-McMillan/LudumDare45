using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceType resource;

    [SerializeField] private float collectionTime = 2.0f;

    [SerializeField] private ToolType toolType = ToolType.NONE;

    private bool playerNear = false;

    private bool canCollect = true;

    private WaitForSeconds waitTime;

    private void Start()
    {
        waitTime = new WaitForSeconds(collectionTime);
    }

    private void Update()
    {
        if (playerNear && Input.GetMouseButton(0))
        {
            if (canCollect && PlayerTools.GetCurrentTool() == toolType)
            {
                StartCoroutine(CollectResource());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerNear = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
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
