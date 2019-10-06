using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolUI : MonoBehaviour
{
    [SerializeField] private ToolType type;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        switch (type)
        {
            case ToolType.AXE:
                PlayerTools.OnAxeUpdate += UpdateUI;
                break;

            case ToolType.SPEAR:
                PlayerTools.OnSpearUpdate += UpdateUI;
                break;

            case ToolType.HAMMER:
                PlayerTools.OnHammerUpdate += UpdateUI;
                break;
        }
    }

    private void OnDisable()
    {
        switch (type)
        {
            case ToolType.AXE:
                PlayerTools.OnAxeUpdate -= UpdateUI;
                break;

            case ToolType.SPEAR:
                PlayerTools.OnSpearUpdate -= UpdateUI;
                break;

            case ToolType.HAMMER:
                PlayerTools.OnHammerUpdate -= UpdateUI;
                break;
        }
    }

    private void UpdateUI(string amount)
    {
        text.text = amount;
    }
}
