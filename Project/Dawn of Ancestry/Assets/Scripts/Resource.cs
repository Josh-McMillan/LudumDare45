﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public static Action<bool> OnShowTip;

    public static Action OnFirstResourceCollect;

    [SerializeField] private ResourceType resource;

    [SerializeField] private float collectionTime = 2.0f;

    [SerializeField] private ToolType toolType = ToolType.NONE;

    private PlayerNear player;

    private bool canCollect = true;

    private WaitForSeconds waitTime;

    private static bool hasCollected = false;

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
                StartCoroutine(RunResourceCollection());
            }
        }
    }

    public void CollectResource()
    {
        if (canCollect)
        {
            StartCoroutine(RunResourceCollection());
        }
    }

    protected IEnumerator RunResourceCollection()
    {
        canCollect = false;
        Inventory.GatherResource(resource, 1);

        if (!hasCollected)
        {
            hasCollected = true;
            OnFirstResourceCollect();
        }

        yield return waitTime;

        canCollect = true;
    }
}
