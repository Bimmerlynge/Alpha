using System;
using InputSystem;
using UnityEngine;

namespace BuilderSystem
{
    public class BuilderSystem : MonoBehaviour
    {
        [SerializeField] private GameObject ghostObj;
        [SerializeField] private GameObject building;
        [SerializeField] private LayerMask groundLayerMask;

        private Camera _mainCamera;
        private Ray _ray;
        private RaycastHit _hit;

        private bool _isBuilding = false;

        [SerializeField] private Grid grid;
        [SerializeField] private Transform gridPos;

        private void Awake()
        {
            _mainCamera = Camera.main;
            
        }

        private void OnEnable()
        {
            InputManager.OnMouseLeft += HandleMouseLeft;
            InputManager.OnBuild += HandleOnBuild;
        }

        private void OnDisable()
        {
            InputManager.OnMouseLeft -= HandleMouseLeft;
            InputManager.OnBuild -= HandleOnBuild;
        }

        private void Update()
        {
            if (!_isBuilding) return;
            MoveGhost();
            
            //Debug.Log("Clicked at: " + (_hit.transform.localPosition - gridPos.position));
            

            //Debug.Log("Bøgggse: "+ grid.WorldToCell(_hit.point));

        }

        private void MoveGhost()
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(_ray, out _hit, 1000f, groundLayerMask))
            {
                ghostObj.SetActive(false);
                return;
            }
            
            ghostObj.SetActive(true);

            var cellPos = _hit.transform.GetComponent<DynamicGrid>().GetCellPosition(_hit.point);
            
            ghostObj.transform.position = cellPos;
        }

        private void HandleMouseLeft()
        {
            PlaceBuilding();
            Debug.Log("BuilderSystem HandleOnBuild");
        }

        private void HandleOnBuild()
        {
            _isBuilding = !_isBuilding;

            if (!_isBuilding)
            {
                Destroy(ghostObj);
                return;
            }

            //SpawnGhost();
            Debug.Log("BuilderSystem HandleOnBuild");
        }

        private void SpawnGhost()
        {
            if (!_isBuilding) return;
            
            ghostObj = Instantiate(building);
        }

        private void PlaceBuilding()
        {
            //_isBuilding = !_isBuilding;
            //Instantiate(building, _hit.point, building.transform.rotation);
            //Destroy(ghostObj);
        }

        private void OnDrawGizmos()
        {
            
        }
    }
}
