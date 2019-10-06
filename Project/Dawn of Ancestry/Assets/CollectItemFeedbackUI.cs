using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemFeedbackUI : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteList;

    [SerializeField] private GameObject feedbackUI;

    private void OnEnable()
    {
        Inventory.OnItemGather += SpawnFeedback;
        PlayerTools.OnToolCollect += SpawnFeedback;
    }

    private void OnDisable()
    {
        Inventory.OnItemGather -= SpawnFeedback;
        PlayerTools.OnToolCollect -= SpawnFeedback;
    }

    private void SpawnFeedback(ResourceType type)
    {
        GameObject newObject = Instantiate(feedbackUI, transform.position, Quaternion.identity);

        CollectItemUI ui = newObject.GetComponent<CollectItemUI>();

        ui.SetSprite(spriteList[(int)type - 1]);
    }

    private void SpawnFeedback(ToolType type)
    {
        GameObject newObject = Instantiate(feedbackUI, transform.position, Quaternion.identity);

        CollectItemUI ui = newObject.GetComponent<CollectItemUI>();

        ui.SetSprite(spriteList[(int)type + 4]);
    }
}
