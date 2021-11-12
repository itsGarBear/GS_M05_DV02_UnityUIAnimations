using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimControls : MonoBehaviour
{
    public enum TypesOfParameters
    {
        floatParam,
        intParam,
        boolParam,
        triggerParam
    };

    [System.Serializable]
    public class ParameterProperties
    {
        public string parameterString;
        public string whichState;

        public TypesOfParameters parameterType;
        public float floatVal;
        public int intVal;
        public bool boolVal;
    }

    [System.Serializable]
    public class AnimatorProperties
    {
        public string name;
        public Animator theAnimator;
        public List<ParameterProperties> animatorProperties;
    }

    public List<AnimatorProperties> animatedItems;
    Animator theStateMachine;

    private void Awake()
    {
        theStateMachine = GetComponent<Animator>();
    }

    public void PlayerInputTrigger(string trigger)
    {
        theStateMachine.SetTrigger(trigger);
    }

    public void CheckForParameterSet()
    {
        foreach(AnimatorProperties animatorProp in animatedItems)
        {
            foreach(ParameterProperties parameter in animatorProp.animatorProperties)
            {
                if(theStateMachine.GetCurrentAnimatorStateInfo(0).IsName(parameter.whichState))
                {
                    if(parameter.parameterType == TypesOfParameters.floatParam)
                    {
                        animatorProp.theAnimator.SetFloat(parameter.parameterString, parameter.floatVal);
                    }
                    else if(parameter.parameterType == TypesOfParameters.intParam)
                    {
                        animatorProp.theAnimator.SetInteger(parameter.parameterString, parameter.intVal);
                    }
                    else if(parameter.parameterType == TypesOfParameters.boolParam)
                    {
                        animatorProp.theAnimator.SetBool(parameter.parameterString, parameter.boolVal);
                    }
                    else
                    {
                        animatorProp.theAnimator.SetTrigger(parameter.parameterString);
                    }
                }
            }
        }
    }

}
