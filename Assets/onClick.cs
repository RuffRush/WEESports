using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Interactions;
using static UnityEditorInternal.ReorderableList;

public class onClick : MonoBehaviour { 

    InputActionReference pressedX = null ;

    private void Awake()
    {
        pressedX.action.started += Toggle;
    }



    // Update is called once per frame
    private void Toggle(InputAction.CallbackContext context)
    {
        bool isActive = gameObject.activeSelf;
        gameObject.SetActive(isActive);
    }
}

