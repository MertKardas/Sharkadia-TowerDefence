using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    
    public static InputManager Instance;
    public MyPlayerInput PlayerInput { private set; get; }

    private void Awake()
    {
        if (Instance == null)
        {
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
            PlayerInput = new MyPlayerInput();
            PlayerInput.UI.Enable();
            PlayerInput.Player.Disable();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SwitchInputMapToPlayer() {
        PlayerInput.UI.Disable();
        PlayerInput.Player.Enable();
    }
   
}
