using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceType resource;

    [SerializeField] private float collectionTime = 2.0f;

    [SerializeField] private ToolType toolType = ToolType.NONE;

    private PlayerNear player;

    private bool canCollect = true;

    private WaitForSeconds waitTime;

    protected void Start()
    {
        player = GetComponent<PlayerNear>();
        waitTime = new WaitForSeconds(collectionTime);
    }

    protected virtual void Update()
    {
        if (player.IsNear && Input.GetMouseButton(0))
        {
            if (canCollect && PlayerTools.GetCurrentTool() == toolType)
            {
                StartCoroutine(CollectResource());
            }
        }
    }

    protected IEnumerator CollectResource()
    {
        canCollect = false;
        Inventory.GatherResource(resource, 1);

        yield return waitTime;

        canCollect = true;
    }
}
