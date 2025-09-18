using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class Building : MonoBehaviour {
    public BuildingState State = BuildingState.Preview;
    [SerializeField] private LayerMask _placableAreaLayer;
    private void Start() {
        InputManager.Instance.PlayerInput.Player.Click.performed += ctx => {
            var buildPosition = InputManager.Instance.GetRealWorldMousePosition(_placableAreaLayer); 
            if(buildPosition != null) {
                State = BuildingState.Placed;
            }

        };
    }
    private void Update() {
        if (State == BuildingState.Preview) {
            Vector3? placementPoint = InputManager.Instance.GetRealWorldMousePosition(_placableAreaLayer);
            if (placementPoint != null) {
                transform.position = placementPoint.Value;
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

