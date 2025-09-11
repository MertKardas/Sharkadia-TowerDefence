using UnityEngine;
using UnityEngine.InputSystem;

public class SelectManager : MonoBehaviour
{
    MyPlayerInput _playerInput; 
    public GameObject pointer;
    [SerializeField]private LayerMask _layerMask; 
    private void Awake() {
        pointer = Instantiate(pointer);
    }
    private void Start()
    {
        _playerInput = InputManager.Instance.PlayerInput; 
        _playerInput.Player.Point.performed += ctx => {
            Ray ray = Camera.main.ScreenPointToRay(_playerInput.Player.Point.ReadValue<Vector2>());
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _layerMask))
            {
                pointer.transform.position = hitInfo.point;
            }
        };
        _playerInput.Player.Click.performed += ctx=> {
            Ray ray = Camera.main.ScreenPointToRay(_playerInput.Player.Point.ReadValue<Vector2>());
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _layerMask))
            {
                Instantiate(pointer, hitInfo.point, Quaternion.identity);
            }
        };

    }
    void Update()
    {
        
    }
}
