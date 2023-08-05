using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndicator, towerPrefab;

    [SerializeField]
    private LayerMask layermask;

    private bool isBuilding = false;

    private Camera _camera;
    private Vector3 lastPosition;

    private void Awake()
    {
        mouseIndicator.SetActive(false);
        _camera = Camera.main;

        InputManager.OnPlace += PlaceTower;
    }

    private void Update()
    {
        mouseIndicator.transform.position = UpdateMouse();
    }

    private Vector3 UpdateMouse() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane;
        Ray ray = _camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layermask)) { 
            lastPosition = hit.point;
        }
        return lastPosition;
    }


    public void BuildTower() {
        if (!mouseIndicator.activeSelf)
        {
            mouseIndicator.SetActive(true);
        }
        isBuilding = true;

    }

    private void PlaceTower() {
        if (!isBuilding) return;

        Instantiate(towerPrefab, lastPosition, Quaternion.identity);
        
        isBuilding = false;
        mouseIndicator.SetActive(false);
    }

}
