using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDefender : StateMachineBehaviour
{
    [SerializeField] private float wanderBox = 5.0f;
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float minWaitTime = 2.5f;
    [SerializeField] private float maxWaitTime = 5.0f;

    private Transform transform;
    private SpriteRenderer sprite;

    private Vector3 spawnPosition = Vector3.zero;
    private Vector3 destination = Vector3.zero;
    private bool hasArrived = false;
    private bool waiting = false;

    private float waitTime = 0.0f;
    private float startWaitTime = 0.0f;

    private bool toolRetrievedSuccessfully = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerTools.ToolAvailable(ToolType.SPEAR))
        {
            PlayerTools.ConsumeTool(ToolType.SPEAR, 1);
            toolRetrievedSuccessfully = true;
        }
        else
        {
            animator.SetTrigger("ToggleTool");
            return;
        }

        transform = animator.transform;
        sprite = animator.GetComponent<SpriteRenderer>();

        spawnPosition = animator.transform.position;
        destination = GenerateRandomPosition(animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!hasArrived)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, destination) == 0.0f)
            {
                hasArrived = true;
            }
        }
        else if (!waiting)
        {
            waiting = true;

            waitTime = Random.Range(minWaitTime, maxWaitTime);
            startWaitTime = Time.time;

            animator.speed = 1.0f;
        }
        else
        {
            if (Time.time >= startWaitTime + waitTime)
            {
                destination = GenerateRandomPosition(animator);
                hasArrived = false;
                waiting = false;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (toolRetrievedSuccessfully)
        {
            PlayerTools.AddTool(ToolType.SPEAR, 1);
        }
    }

    private Vector3 GenerateRandomPosition(Animator animator)
    {
        Vector2 random;
        Vector3 returnValue;

        random.x = Random.Range(spawnPosition.x - wanderBox, spawnPosition.x + wanderBox);
        random.y = Random.Range(spawnPosition.y - wanderBox, spawnPosition.y + wanderBox);

        if (Physics2D.OverlapPoint(random))
        {
            returnValue = GenerateRandomPosition(animator);
        }
        else
        {
            returnValue = new Vector3(random.x, random.y, 0.0f);
        }

        SetSpriteDirection(returnValue.x);
        animator.speed = 2.0f;

        return returnValue;
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
