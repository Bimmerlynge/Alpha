using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputs _actions;

    public delegate void KeyAction(string key);
    public static KeyAction OnKeyPressed, OnKeyReleased;

    public delegate void PlaceAction();
    public static PlaceAction OnPlace;

    private void OnEnable()
    {
        _actions = new PlayerInputs();
        _actions.Enable();

        _actions.Player.Enable();

        _actions.Player.Camera.started += KeyPressed;
        _actions.Player.Camera.canceled += KeyRelease;

        _actions.Player.Place.performed += Place;

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

    private void Place(InputAction.CallbackContext context) {

        OnPlace?.Invoke();
    
    }
}
