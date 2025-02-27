using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimationController : MonoBehaviour
{
    private Animator ChestHingeController;
    private bool isAnimating = false;

    private void Start()
    {
        ChestHingeController = GetComponent<Animator>();
        ChestHingeController.Play("frozenchestLidAnimation");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isAnimating)
        {
            Debug.Log("Space key pressed!");
            ChestHingeController.SetTrigger("Open Chest Trigger");
            isAnimating = true;
        }

        if(isAnimating && ChestHingeController.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {

            //animator.ResetTrigger("chestcloseAnimation");

            isAnimating = false;
        }
    }
}
