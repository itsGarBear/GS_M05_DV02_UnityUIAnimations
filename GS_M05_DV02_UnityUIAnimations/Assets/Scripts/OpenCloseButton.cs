using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseButton : MonoBehaviour
{
    Text buttonText;
    Animator chestAnimController;

    private void Awake()
    {
        buttonText = transform.GetComponentInChildren<Text>();
        chestAnimController = Camera.main.GetComponent<Animator>();
    }

    public void OpenOrClose()
    {
        print("Click");
        if(buttonText.text == "Open")
        {
            chestAnimController.SetTrigger("OpenChest");
            SetText("Close");
        }
        else
        {
            chestAnimController.SetTrigger("CloseChest");
            SetText("Open");
        }
    }

    public void SetText(string setTextTo)
    {
        buttonText.text = setTextTo;
    }
}
