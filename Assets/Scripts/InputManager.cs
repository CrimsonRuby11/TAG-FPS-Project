using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.MainActions main;
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerInteract interact;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        main = playerInput.Main;
        motor = GetComponent<PlayerMotor>();
        interact = GetComponent<PlayerInteract>();
        look = GetComponent<PlayerLook>();

        main.Jump.performed += ctx => motor.jump();
        main.Shoot.performed += ctx => interact.isShot = true;
        main.Morph.performed += ctx => interact.isMorph = true;
    }

    void FixedUpdate()
    {
        if (!PlayerInteract.isPaused)
        {
            motor.processMove(main.Movement.ReadValue<Vector2>());
        }
        
    }

    private void LateUpdate()
    {
        if (!PlayerInteract.isPaused)
        {
            look.processLook(main.Look.ReadValue<Vector2>());
        }
    }

    private void OnEnable()
    {
        main.Enable();
    }

    private void OnDisable()
    {
        main.Disable();
    }
}
