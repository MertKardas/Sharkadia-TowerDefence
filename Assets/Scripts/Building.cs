using NaughtyAttributes;
using System;
using System.Collections;
using UnityEngine;

public class Building : MonoBehaviour {
    private Renderer[] _renderers;
    private bool _showPreview = false; 
    private BuildingState _state = BuildingState.Preview;
    public BuildingState State { 
        get => _state; 
        set {
            _state = value;
            OnBuildingStateChange?.Invoke(_state);
        }
    } 
    public Action<BuildingState> OnBuildingStateChange;
    [SerializeField] private LayerMask _placableAreaLayer;
    private void Start() {
        InputManager.Instance.PlayerInput.Player.Click.performed += ctx => {
            var buildPosition = InputManager.Instance.GetRealWorldMousePosition(_placableAreaLayer);
            if (buildPosition != null) {
                State = BuildingState.Placed;
            }

        };
        
    }
    private void Awake() {
        _renderers = GetComponentsInChildren<Renderer>();
        foreach (var rend in _renderers) {
            rend.gameObject.SetActive(false);
        }
    }
    private void Update() {
        if (State == BuildingState.Preview) {
            Vector3? placementPoint = InputManager.Instance.GetRealWorldMousePosition(_placableAreaLayer);
            if (!_showPreview && placementPoint != null) {
                foreach (var rend in _renderers) {
                    rend.gameObject.SetActive(true);
                }
                _showPreview = true;
            }
            if (placementPoint != null) {
                transform.position = placementPoint.Value;
            } else {
                foreach (var rend in _renderers) {
                    rend.gameObject.SetActive(false);
                }
                _showPreview = false;
            }
        }
    }

}
public enum BuildingState {
    Preview,
    Placed,
    Built,
    Upgrading,
    Demolished

}

