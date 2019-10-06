using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.25f;

    private Transform player;
    private Vector3 velocity;

    private Vector3 offsetPos = new Vector3(0.0f, 0.0f, -10.0f);

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offsetPos, ref velocity, speed);
    }
}
