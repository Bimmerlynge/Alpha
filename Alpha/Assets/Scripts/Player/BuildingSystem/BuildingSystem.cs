using System;
using System.Collections;
using System.Collections.Generic;
using InputSystem;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] private GameObject ghostObj;
    
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask groundLayerMask;
    
    private Ray _ray;
    private RaycastHit _hit;

    private bool isBuilding = false;
    private void Awake()
    {
        InputManager.OnBuild += HandleBuild;
    }

    private void HandleBuild()
    {
        isBuilding = !isBuilding;
    }

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(_ray, out _hit, 100f, groundLayerMask))
        {
            Debug.Log("Not hitting");
            return;
        }

        
        //Debug.Log("Inverse cord? " + _hit.transform.InverseTransformPoint(_hit.point));
        //Debug.Log("Raycast: " + _hit.point);
    }

    private void OnDrawGizmos()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        Debug.DrawRay(_ray.origin, _ray.direction * 100, Color.blue, 2f);
    }
}
