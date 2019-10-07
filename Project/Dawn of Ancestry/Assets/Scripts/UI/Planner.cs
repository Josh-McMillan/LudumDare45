using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlannerState
{
    NONE,
    FARM,
    CAMPFIRE,
    HUT
}

public class Planner : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.25f;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private Sprite[] structures;
    [SerializeField] private GameObject[] structurePrefabs;
    [SerializeField] private Color canPlaceColor;
    [SerializeField] private Color blockedColor;

    private SpriteRenderer sprite;
    private ContactFilter2D filter2D;
    private Collider2D[] colliders = new Collider2D[2];

    private PlannerState currentState = PlannerState.NONE;

    private Vector3 mousePosition;

    private bool canPlace = false;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        ClosePlanner();
    }

    private void OnEnable()
    {
        StructureMenu.OnBuildStructure += ActivatePlanner;
    }

    private void OnDisable()
    {
        StructureMenu.OnBuildStructure -= ActivatePlanner;
    }

    public void ActivatePlanner(PlannerState state)
    {
        switch (state)
        {
            case PlannerState.FARM:
                currentState = PlannerState.FARM;
                sprite.sprite = structures[0];
                break;

            case PlannerState.CAMPFIRE:
                currentState = PlannerState.CAMPFIRE;
                sprite.sprite = structures[1];
                break;

            case PlannerState.HUT:
                currentState = PlannerState.HUT;
                sprite.sprite = structures[2];
                break;
        }
    }

    private void Update()
    {
        switch (currentState)
        {
            case PlannerState.FARM:
                MoveWithMouse();
                CheckForCancel();
                CheckPlacement();

                if (Input.GetMouseButtonDown(0) && canPlace)
                {
                    if (Inventory.CheckResourceAvailable(ResourceType.STICK, 10) && Inventory.CheckResourceAvailable(ResourceType.WOOD, 5))
                    {
                        Inventory.ConsumeResource(ResourceType.STICK, 10);
                        Inventory.ConsumeResource(ResourceType.WOOD, 5);
                        Instantiate(structurePrefabs[0], mousePosition, Quaternion.identity);
                        ClosePlanner();
                    }
                }

                break;

            case PlannerState.CAMPFIRE:
                MoveWithMouse();
                CheckForCancel();
                CheckPlacement();

                if (Input.GetMouseButtonDown(0) && canPlace)
                {
                    if (Inventory.CheckResourceAvailable(ResourceType.PEBBLE, 20) && Inventory.CheckResourceAvailable(ResourceType.STICK, 10))
                    {
                        Inventory.ConsumeResource(ResourceType.PEBBLE, 20);
                        Inventory.ConsumeResource(ResourceType.STICK, 10);
                        Instantiate(structurePrefabs[1], mousePosition, Quaternion.identity);
                        ClosePlanner();
                    }
                }

                break;

            case PlannerState.HUT:
                MoveWithMouse();
                CheckForCancel();
                CheckPlacement();

                if (Input.GetMouseButtonDown(0) && canPlace)
                {
                    if (Inventory.CheckResourceAvailable(ResourceType.STONE, 20) && Inventory.CheckResourceAvailable(ResourceType.WOOD, 10))
                    {
                        Inventory.ConsumeResource(ResourceType.STONE, 20);
                        Inventory.ConsumeResource(ResourceType.WOOD, 10);
                        Instantiate(structurePrefabs[2], mousePosition, Quaternion.identity);
                        ClosePlanner();
                    }
                }
                break;
        }
    }

    public void CheckForCancel()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ClosePlanner();
        }
    }

    private void ClosePlanner()
    {
        currentState = PlannerState.NONE;
        sprite.sprite = null;
        canPlace = false;
    }

    public void CheckPlacement()
    {
        int objectCount = Physics2D.OverlapCircleNonAlloc(transform.position, radius, colliders);

        if (objectCount > 0)
        {
            Debug.Log("Can't place! " + objectCount + " objects are in the way!");
            canPlace = false;
            sprite.color = blockedColor;
        }
        else
        {
            Debug.Log("Feel free to place! Object count: " + objectCount);
            canPlace = true;
            sprite.color = canPlaceColor;
        }
    }

    private void MoveWithMouse()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0.0f;

        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
