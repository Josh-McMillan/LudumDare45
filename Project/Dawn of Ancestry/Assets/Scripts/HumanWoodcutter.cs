using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanWoodcutter : StateMachineBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float stopDistance = 1.0f;

    private Transform transform;
    private SpriteRenderer sprite;
    private Collider2D collider;

    private GameObject selectedTree = null;
    private Collider2D selectedTreeCollider = null;
    private Resource woodCollection;

    private bool arrivedAtTree = false;
    private bool toolRetrievedSuccessfully = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.transform;
        sprite = animator.GetComponent<SpriteRenderer>();
        collider = animator.GetComponent<Collider2D>();

        if (PlayerTools.ToolAvailable(ToolType.AXE))
        {
            PlayerTools.ConsumeTool(ToolType.AXE, 1);
            toolRetrievedSuccessfully = true;
        }
        else
        {
            animator.SetTrigger("ToggleTool");
            return;
        }

        selectedTree = FindNearestTree();
        selectedTreeCollider = selectedTree.GetComponent<Collider2D>();
        woodCollection = selectedTree.GetComponentInChildren<Resource>();

        SetSpriteDirection(selectedTree.transform.position.x);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!arrivedAtTree)
        {
            transform.position = Vector2.MoveTowards(transform.position, selectedTree.transform.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, selectedTree.transform.position) <= stopDistance)
            {
                arrivedAtTree = true;
            }
        }
        else
        {
            woodCollection.CollectResource();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (toolRetrievedSuccessfully)
        {
            PlayerTools.AddTool(ToolType.AXE, 1);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    private GameObject FindNearestTree()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Tree");

        GameObject closestTree = null;
        float distance = Mathf.Infinity;

        Vector3 position = transform.position;

        foreach (GameObject go in gameObjects)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                closestTree = go;
                distance = curDistance;
            }
        }

        return closestTree;
    }

    private void SetSpriteDirection(float xDestination)
    {
        if (xDestination < transform.position.x)
        {
            sprite.flipX = true;
        }
        else if (xDestination > transform.position.x)
        {
            sprite.flipX = false;
        }
    }
}
