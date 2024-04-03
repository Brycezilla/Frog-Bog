using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    private Animator animator;
    private InputState inputState;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        inputState = GetComponent<InputState>();
        //RuntimeAnimatorController Controller = (RuntimeAnimatorController)Resources.Load("Animation/blue");
       // animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Assets/Animations/blue", typeof(RuntimeAnimatorController));

    }

    // Update is called once per frame
    void Update()
    {
        //animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Assets/Animations/blue");
        //RuntimeAnimatorController Controller = (RuntimeAnimatorController)Resources.Load("Animations/blue");
        var jumping = false;
        var croaking = false;
        if (inputState.absVelX > 0)// && inputState.absVelY < inputState.standingThreshold)
            jumping = true;

        if (Input.GetKeyDown("c"))
            croaking = true;
        animator.SetBool("Jumping", jumping);
    }
}
