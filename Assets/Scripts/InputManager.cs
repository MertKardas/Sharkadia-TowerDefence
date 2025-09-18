using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class InputManager : MonoBehaviour {

    public static InputManager Instance;
    public Vector2 MousePosition => Mouse.current.position.ReadValue();
    public MyPlayerInput PlayerInput { private set; get; }

    private void Awake() {
        if (Instance == null) {

            Instance = this;
            DontDestroyOnLoad(gameObject);
            PlayerInput = new MyPlayerInput();
            PlayerInput.UI.Enable();
            PlayerInput.Player.Enable();
        } else {
            Destroy(gameObject);
        }
    }

    public void SwitchInputMapToPlayer() {
        PlayerInput.UI.Disable();
        PlayerInput.Player.Enable();
    }
    public  Vector3? GetRealWorldMousePosition(LayerMask layer) {
        //Check if outside viewport 
        if (MousePosition.x < 0 || MousePosition.x > Screen.width || MousePosition.y < 0 || MousePosition.y > Screen.height) {
            return null;
        }
        //Check if over UI
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
            return null;
        }
        Ray ray = Camera.main.ScreenPointToRay(MousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layer)) {
            return hit.point;
        }
        return null;
    }
    
}