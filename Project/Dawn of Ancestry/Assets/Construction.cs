using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    public static Action<GameObject> OnConstructionComplete;

    [SerializeField] private Sprite[] spriteSheet;

    [SerializeField] private float buildSpeed;

    [SerializeField] private ToolType requiredTool;

    private PlayerNear player;

    private float progress;

    private bool isBuilt = false;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = transform.GetChild(0).GetComponent<PlayerNear>();
    }

    public bool IsBuilt
    {
        get { return isBuilt; }
    }

    private void Update()
    {
        if (!isBuilt)
        {
            if (Input.GetMouseButton(0) && player.IsNear)
            {
                if (requiredTool == ToolType.NONE)
                {
                    BuildStructure();
                }
                else if (PlayerTools.GetCurrentTool() == requiredTool)
                {
                    BuildStructure();
                }
            }
        }
    }

    private void BuildStructure()
    {
        progress += buildSpeed;

        sprite.sprite = GetCurrentSprite();

        if (progress >= 100.0f)
        {
            progress = 100.0f;
            isBuilt = true;
            OnConstructionComplete(gameObject);
        }
    }

    public Sprite GetCurrentSprite()
    {
        if (progress < 33.34f)
        {
            return spriteSheet[0];
        }
        else if (progress < 66.67f)
        {
            return spriteSheet[1];
        }
        else if (progress < 99.99)
        {
            return spriteSheet[2];
        }
        else
        {
            return spriteSheet[3];
        }
    }
}
