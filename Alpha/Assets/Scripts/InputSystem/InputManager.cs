using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInputActions _actions;
        
        

        public static event Action OnMouseLeft;
        public static event Action OnBuild;

        private void OnEnable()
        {
            _actions = new PlayerInputActions();
            _actions.Enable();
            _actions.Player.Enable();
            
            EnableInputListeners();
        }
        
        private void OnDisable()
        {
            DisableInputListeners();
        }

        private void EnableInputListeners()
        {
            _actions.Player.MouseLeft.performed += MouseLeft;
            _actions.Player.Build.performed += Build;
        }
        private void DisableInputListeners()
        {
            _actions.Player.MouseLeft.performed -= MouseLeft;
            _actions.Player.Build.performed -= Build;
            
            _actions.Disable();
        }


        private void MouseLeft(InputAction.CallbackContext context)
        {
            OnMouseLeft?.Invoke();
        }

        private void Build(InputAction.CallbackContext context)
        {
            OnBuild?.Invoke();
        }
    }
}
