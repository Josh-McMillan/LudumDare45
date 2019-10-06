using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.25f;

    private Transform player;
    private Vector3 target;
    private Vector3 velocity;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        target = Vector3.SmoothDamp(transform.position, player.position, ref velocity, speed);

        transform.position = new Vector3(Mathf.Clamp(target.x, -16.0f, 16.0f), Mathf.Clamp(target.y, -20.0f, 20.0f), -10.0f);
    }
}
