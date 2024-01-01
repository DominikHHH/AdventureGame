using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //*---------------------------------------------*
    //
    //  The player's main input/collision detection code
    //
    //*---------------------------------------------*

    // Inputs
    [HideInInspector] public Vector3 moveInput;
    [HideInInspector] public bool runInput;

    public InputActionMap inputs;

    // Player physics
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public float moveAccel;
    [HideInInspector] public float currentGravity;

    public Vector3 movingPlatformSpeed;

    // Main components
    PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    void Start()
    {
        inputs.Enable();
    }

    private void Update()
    {
        // Update basic physics mechanics and inputs, regardless of the player's current state
        HandleInputs();

        
        HandleDirection();
    }

    private void LateUpdate()
    {
        HandleGravity();
    }

    // Move the player vertically depending on how much ground is below them right now
    private void HandleGravity()
    {
        RaycastHit[] groundCheck = Physics.RaycastAll(transform.position, Vector3.down, Mathf.Infinity, controller.GroundLayer);
        if (groundCheck.Length <= 0) 
        {
            // Let the player fall if there is no object below them at all
            if (currentGravity <= controller.Gravity) { currentGravity += controller.GravityAccel; }
            controller.cc.Move(Vector3.down * currentGravity * Time.deltaTime);
        }
        else
        {
            foreach (RaycastHit hit in groundCheck)
            {
                // Check to make sure the player is actively levitating above the ground right now before applying gravity
                if (!controller.cc.isGrounded)
                {
                    if (currentGravity <= controller.Gravity) { currentGravity += controller.GravityAccel; }
                    controller.cc.Move(Vector3.down * currentGravity * Time.deltaTime);
                }
                else
                {
                    switch (hit.collider.tag.ToString())
                    {
                        case "MovingPlatform":
                            // Use additional speed to make sure the player stays on the current platform
                            movingPlatformSpeed = hit.collider.GetComponent<MovingPlatform>().currentSpeed;
                            break;

                        case "Stairs":
                            // Use lots of gravity to ensure the player is stuck to the ground
                            controller.cc.Move(Vector3.down * 100 * Time.deltaTime);
                            break;

                        case "Untagged":
                        default:
                            currentGravity = 0;
                            movingPlatformSpeed = Vector3.zero;
                            break;
                    }
                }
            }
        }
    }

    // Find the appropriate direction vector for the player to move in
    private void HandleDirection()
    {
        if (moveInput != Vector3.zero)
        {
            direction = moveInput;
        }
    }

    // Reading all of the player's current inputs and updating all associated variables
    private void HandleInputs()
    {
        Vector2 vector2 = inputs.FindAction("Move").ReadValue<Vector2>();;
        moveInput = new Vector3(-vector2.x, 0, -vector2.y);

        runInput = inputs.FindAction("Run").IsPressed();
    }

}
