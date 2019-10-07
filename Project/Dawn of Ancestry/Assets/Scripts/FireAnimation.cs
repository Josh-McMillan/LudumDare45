using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FireAnimation : MonoBehaviour
{
    [SerializeField] private float minIntensity = 0.75f;
    [SerializeField] private float maxIntensity = 1.5f;
    [SerializeField] private float flickerSpeed = 2.0f;
    [SerializeField] private float minX = -1.0f;
    [SerializeField] private float maxX = 1.0f;
    [SerializeField] private float movementSpeed = 1.5f;

    private float flickerSeed;
    private float movementSeed;
    private Light fire;
    private Animator animator;
    private bool animateFire = false;
    private bool fireStarted = false;

    private void Start()
    {
        flickerSeed = Random.Range(0.0f, 65535.0f);
        movementSeed = Random.Range(0.0f, 65535.0f);
        fire = GetComponent<Light>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.anyKeyDown && !fireStarted)
        {
            fireStarted = true;
            animator.SetTrigger("FlameUp");
        }

        if (!animator.enabled)
        {
            Animate();
        }
    }

    public void Animate()
    {
        float flickerNoise = Mathf.PerlinNoise(flickerSeed, Time.time * flickerSpeed);
        fire.intensity = Mathf.Lerp(minIntensity, maxIntensity, flickerNoise);

        float movementNoise = Mathf.PerlinNoise(Time.time * movementSpeed, flickerSeed);
        float x = Mathf.Lerp(minX, maxX, movementNoise);

        transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
    }
}
