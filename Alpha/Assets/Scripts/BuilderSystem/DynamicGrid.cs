using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGrid : MonoBehaviour
{
    [SerializeField] private int height, width, planeWidth, planeHeight;
    
    [SerializeField]
    private Transform gridPlane;

    [SerializeField] private GameObject cellCenterVisuals, cellMarker;

    private int defaultCellSize = 10;

    private Transform _transform;

    [SerializeField] private List<Vector2Int> gridCenters;
    
    [SerializeField] private GameObject OffsetMarker;
    
    [SerializeField]
    private Vector2Int _cellOffset;


    [SerializeField] private GameObject ghostObj;

    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField]
    private Camera _camera;
    [SerializeField] private LayerMask groundLayerMask;
    
    private void Start()
    {
        InitGrid();
        
    }

    private void Update()
    {
        if (!ghostObj.activeSelf) return;
        
        
        GetClosestsCell();
        
        
    }

    private void GetClosestsCell()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (!Physics.Raycast(_ray, out _hit, 100f, groundLayerMask))
        {
            //Debug.Log("Not hitting");
            return;
        }
        
        Vector2Int closests = gridCenters[0];
        float closestDist = Vector3.Distance(new Vector3(closests.x, 0, closests.y), _hit.point);

        foreach (var cell in gridCenters)
        {
            float dist = Vector3.Distance(new Vector3(cell.x, 0, cell.y), _hit.point);
            if (dist < closestDist)
            {
                closests = cell;
                closestDist = dist;
            }
        }

        ghostObj.transform.position = new Vector3(closests.x, 0, closests.y);
        //Debug.Log("Inverse cord? " + _hit.transform.InverseTransformPoint(_hit.point));
    }

    private void ShowOffset()
    {
        
        OffsetMarker.transform.position = new Vector3(_cellOffset.x, 0 , _cellOffset.y);
    }

    private void InitGrid()
    {
        _cellOffset = new Vector2Int(-5 * (width - 1), 5 * (height - 1));
        
        Debug.Log("Initializing grid");
        gridCenters.Clear();
        for (int i = _cellOffset.x; i <= _cellOffset.x * -1; i += defaultCellSize)
        {
            
            for (int j = _cellOffset.y; j >= _cellOffset.y * -1; j -= defaultCellSize)
            {
                //Debug.Log($"Iteration: ({i}, {j})");
                var vector = new Vector2Int(i, j);
                gridCenters.Add(vector);
            }
        }
    }

    private void SetPlaneDimensions()
    {
        planeHeight = height * 10;
        planeWidth = width * 10;
        
        InitGrid();
        ShowOffset();
        //FillGridList();
    }

    private void FillGridList()
    {
        gridCenters.Clear();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                
            }
        }
    }


    private void OnValidate()
    {
        SetPlaneDimensions();
        Debug.Log($"OnValidate: {this}");
        
        gridPlane.GetComponent<Renderer>().sharedMaterial.SetVector("_Dimensions", new Vector4(width,height));

        gridPlane.localScale = new Vector3(width, 1, height);
        ShowCellCenters();
    }

    private void ShowCellCenters()
    {
       StartCoroutine(CellCenterVisual());
    }

    private IEnumerator CellCenterVisual()
    {
        ClearCellCenterVisual();
        yield return null;
        SpawnCellCenterVisual();
    }

    private void SpawnCellCenterVisual()
    {
        foreach (var coord in gridCenters)
        {
            Instantiate(cellMarker, new Vector3(coord.x, 0, coord.y), Quaternion.identity, cellCenterVisuals.transform);
            
        }
    }

    private IEnumerator ClearCellCenterVisualCoroutine()
    {
        yield return null; // Wait for the next frame
        var children = cellCenterVisuals.GetComponentsInChildren<Transform>();
    
        Debug.Log("To clear: " + children.Length);
        foreach (var child in children)
        {
            if (child != cellCenterVisuals.transform) // Skip the parent transform
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }

    private void ClearCellCenterVisual()
    {
        StartCoroutine(ClearCellCenterVisualCoroutine());
    }

    public Vector3 GetCellPosition(Vector3 worldPos)
    {
        return Vector3.back;
    }


    public void EnableShader(bool value = true)
    {
        Debug.Log($"Enable shader: {value}");
        transform.GetChild(0).gameObject.SetActive(value);
    }
}
