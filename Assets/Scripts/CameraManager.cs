using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _zoomSpeed = 15f;
    [SerializeField] private float _minFOV = 5f;
    [SerializeField] private float _maxFOV = 100f;
    [SerializeField] private CinemachineCamera _vCamera;

    private Vector2 _movementInput;
    private float _zoomInput;
    private MyPlayerInput _playerInput;


    

    private void SetupInputCallbacks()
    {
        // Store input values, don't calculate movement here
        _playerInput.Player.Movement.performed += ctx => {
            _movementInput = ctx.ReadValue<Vector2>();
        };
        
        _playerInput.Player.Movement.canceled += ctx => {
            _movementInput = Vector2.zero;
        };
        
        _playerInput.Player.Zoom.performed += ctx => {
            _zoomInput = ctx.ReadValue<float>();
        };
        
        _playerInput.Player.Zoom.canceled += ctx => {
            _zoomInput = 0f;
        };
        
    }

    private void OnEnable()
    {
        //_playerInput?.Enable();
    }

    private void OnDisable()
    {
        //_playerInput?.Disable();
    }

    private void Start()
    {
        if (_vCamera is null) Debug.LogError("VÝrtual Camera not assigned ");
        _playerInput = InputManager.Instance.PlayerInput;
        SetupInputCallbacks();
    }

    private void Update()
    {
        if (_vCamera is null) return;

        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement()
    {
        if (_movementInput != Vector2.zero)
        {
            Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y);
            _vCamera.transform.Translate(movement * _moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private void HandleZoom() {
        if (_zoomInput != 0f) {
            Vector3 currentPosition = _vCamera.transform.position;
            float newY = currentPosition.y - (_zoomInput * _zoomSpeed * Time.deltaTime);
            newY = Mathf.Clamp(newY, _minFOV, _maxFOV);
            _vCamera.transform.position = new Vector3(currentPosition.x, newY, currentPosition.z);
        }
    }

    private void OnDestroy()
    {
        _playerInput?.Dispose();
    }
}