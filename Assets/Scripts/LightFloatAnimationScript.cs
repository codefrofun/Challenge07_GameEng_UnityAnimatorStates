using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFloatAnimationScript : MonoBehaviour
{
    private Animator LightAnimationController;

    private float pulseSpeed = 0f;

    public float minPulseSpeed = 0f;
    public float maxPulseSpeed = 15f;

    public Material yellowMaterial;
    public Material greenMaterial;
    public Material blueMaterial;

    private Renderer cubeRenderer;

    private Light cubeLight;

    public float minLightIntensity = 1f;
    public float maxLightIntensity = 10f;

    private void Start()
    {
        LightAnimationController = GetComponent<Animator>();
        cubeRenderer = GetComponent<Renderer>();
        cubeLight = GetComponentInChildren<Light>();

        if (cubeLight != null)
        {
            cubeLight.intensity = minLightIntensity;
        }
    }

    void Update()
    {
        float scrollInput = Input.mouseScrollDelta.y;

        if (scrollInput != 0)
        {
            // To adjust speed based on scroll input
            pulseSpeed += scrollInput * 0.2f;
            pulseSpeed = Mathf.Clamp(pulseSpeed, minPulseSpeed, maxPulseSpeed);

            LightAnimationController.SetFloat("PulseSpeed", pulseSpeed);
        }

        if (pulseSpeed < 1)
        {
            cubeRenderer.material.color = yellowMaterial.color;
        }
        else if (pulseSpeed >= 1 && pulseSpeed < 2)
        {
            cubeRenderer.material.color = greenMaterial.color;
        }
        else
        {
            cubeRenderer.material.color = blueMaterial.color;
        }

        if (cubeLight != null)
        {
            //ping pong math to increase light intensity, depending on scroll speed
            cubeLight.intensity = Mathf.PingPong(pulseSpeed, maxLightIntensity - minLightIntensity) + minLightIntensity;
        }
    }
}
