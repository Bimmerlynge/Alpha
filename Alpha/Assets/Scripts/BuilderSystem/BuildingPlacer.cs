using System;
using InputSystem;
using UnityEngine;

namespace BuilderSystem
{
    public class BuildingPlacer : MonoBehaviour
    {
        [SerializeField] private GameObject ghostBuilding;
        [SerializeField] private GameObject buildingToBuild;
        [SerializeField] private DynamicGrid grid;
        [SerializeField] private Camera camera;
        [SerializeField] private LayerMask layerMask;

        private bool isBuilding = false;
        
        private void OnEnable()
        {
            InputManager.OnBuild += OnBuild;
            InputManager.OnMouseLeft += PlaceTower;
        }

        private void OnDisable()
        {
            InputManager.OnBuild -= OnBuild;
            InputManager.OnMouseLeft -= PlaceTower;
        }

        private void OnBuild()
        {
            if (isBuilding) return;
            isBuilding = true;
            grid.EnableShader();
        }

        private void PlaceTower()
        {
            if (!isBuilding) return;
            isBuilding = false;
            grid.EnableShader(false);
        }
        
        
    }
}