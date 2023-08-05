using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 moveDirection;

    private void OnEnable()
    {
        InputManager.OnKeyPressed += GetMoveVector;
        InputManager.OnKeyReleased += ResetMovement;
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void ResetMovement(string input) { 
        moveDirection = Vector3.zero;
    }

    void GetMoveVector(string input)
    {
        Vector3 inputVector = Vector3.zero;
        switch (input)
        {
            case "w":
                inputVector = Vector3.forward;
                break;
            case "a":
                inputVector = Vector3.left;
                break;
            case "s":
                inputVector = Vector3.back;
                break;
            case "d":
                inputVector = Vector3.right;
                break;
        }
        moveDirection = (moveDirection + inputVector).normalized;
    }

    void HandleMovement() { 
        transform.Translate(moveDirection * 0.2f, Space.World);
        //transform.Translate(moveDirection);
    
    }
}
