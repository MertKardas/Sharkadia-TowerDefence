using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;
/*
public class ReplaceManager : MonoBehaviour {
    private MyPlayerInput _playerInput;
    [HideInInspector] public GameObject pointer;
    [SerializeField] private LayerMask _layerMask;
    public GameObject buildingGameObject;
    private BuildingBar _buildingBar;

    private void Start() {
        _buildingBar = FindAnyObjectByType<BuildingBar>();
        _buildingBar.OnSelectedBuildingChanged += BuildingBar_OnSelectedBuildingChanged;
        InputManager.Instance.PlayerInput.Player.Click.performed += Click_performed;
    }

    private void Click_performed(InputAction.CallbackContext context) {
        if(buildingGameObject != null  ) {
            Vector3? worldPos = InputManager.Instance.GetRealWorldMousePosition(_layerMask);
            if (worldPos == null) return;
            buildingGameObject.transform.position = worldPos.Value;
            Building building = buildingGameObject.GetComponent<Building>();

            if (building.TryPlace()) {
                buildingGameObject = null;
            }
        }
    }

    private void BuildingBar_OnSelectedBuildingChanged(BuildingSO newBuilding) {
        if (newBuilding != null) {
            if (buildingGameObject != null)
                Destroy(buildingGameObject);
            buildingGameObject = Instantiate(newBuilding.buildingPrefab, Vector3.zero, Quaternion.identity);
            buildingGameObject.GetComponent<Building>().BuildingSO = newBuilding;
        } else {
            if (buildingGameObject != null)
                Destroy(buildingGameObject);
        }

    }
    private void Update() {
        if(InputManager.Instance.GetRealWorldMousePosition(_layerMask) is Vector3 position && buildingGameObject != null) {
            Debug.Log("Yer deðiþtirme"); 
            buildingGameObject.transform.position = position;
        }
    }
}*/