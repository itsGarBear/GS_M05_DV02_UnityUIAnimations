using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatonControls : MonoBehaviour
{
    Animator chestAnimController;

    private void Awake()
    {
        chestAnimController = Camera.main.GetComponent<Animator>();
    }

    public void ProceedStateMachine()
    {
        chestAnimController.SetTrigger("AnimationComplete");
    }
}
