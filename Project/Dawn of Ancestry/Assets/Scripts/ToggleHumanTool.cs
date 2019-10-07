using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleHumanTool : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchTool()
    {
        animator.SetTrigger("ToggleTool");
    }

    private void OnMouseDown()
    {
        Debug.Log("Human clicked!");
        SwitchTool();
    }
}
