using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FireAnimation : MonoBehaviour
{
    [SerializeField] private float minIntensity = 0.75f;
    [SerializeField] private float maxIntensity = 1.5f;
    [SerializeField] private float flickerSpeed = 2.0f;

    private float random;
    private Light fire;
    private Animator animator;
    private bool animateFire = false;
    private bool fireStarted = false;

    private void Start()
    {
        random = Random.Range(0.0f, 65535.0f);
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
        float noise = Mathf.PerlinNoise(random, Time.time * flickerSpeed);
        fire.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
