using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputs _actions;

    public delegate void KeyAction(string key);
    public static KeyAction OnKeyPressed, OnKeyReleased;

    private void OnEnable()
    {
        _actions = new PlayerInputs();
        _actions.Enable();

        _actions.Player.Enable();

        _actions.Player.Camera.started += KeyPressed;
        _actions.Player.Camera.canceled += KeyRelease;

    }

    private void OnDisable()
    {
        
    }

    private void KeyPressed(InputAction.CallbackContext context) {
        var key = context.control.name;

        OnKeyPressed?.Invoke(key);
    }

    private void KeyRelease(InputAction.CallbackContext context) {
        var key = context.control.name;

        OnKeyReleased?.Invoke(key);
    }
}
