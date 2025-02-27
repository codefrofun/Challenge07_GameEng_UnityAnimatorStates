using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFloatAnimationScript : MonoBehaviour
{
    private Animator LightAnimationController;

    private float pulseSpeed = 0f;

    public float minPulseSpeed = 0f;
    public float maxPulseSpeed = 15f;

    private void Start()
    {
        LightAnimationController = GetComponent<Animator>();
    }

    void Update()
    {
        float scrollInput = Input.mouseScrollDelta.y;

        if(scrollInput != 0)
        {
            pulseSpeed += scrollInput * 0.5f; // To adjust speed based on scroll input
            pulseSpeed = Mathf.Clamp(pulseSpeed, minPulseSpeed, maxPulseSpeed);

            LightAnimationController.SetFloat("PulseSpeed", pulseSpeed);
        }
    }
}
