using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid = BuilderSystem.Grid;

public class BuilderView : MonoBehaviour
{
    [SerializeField] private List<GameObject> grids;

    public void EnableGridShader()
    {
        grids[0].SetActive(true);
    }

    public void DisableGridShader()
    {
        grids[0].SetActive(false);
    }

    public void UpdateGrids(IList<Grid> grids)
    {
        
    }
}
