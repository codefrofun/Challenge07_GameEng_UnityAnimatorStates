using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerScript : MonoBehaviour
{   
    // Created animator variable
    public Animator CubeAnimationController;

    void Start()
    {
        // Grab the animator game object
        CubeAnimationController = gameObject.GetComponent<Animator>();
        //set idle to true on start
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("tab has been pressed");
            if (!CubeAnimationController.GetBool("Rotate"))
            {
                Debug.Log("Is rotating");
                CubeAnimationController.SetBool("Rotate", true);
            }
            else
            {
                Debug.Log("Is in idle");
                CubeAnimationController.SetBool("Rotate", false);
            }
        }
    }
}
