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
    public Vector3 moveInput;
    public bool runInput;

    public InputActionMap inputs;

    // Player physics
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public float moveAccel;
    [HideInInspector] public float gravityAccel;

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
        HandleGravity();
        HandleDirection();

        HandleInputs();
    }

    private void HandleGravity()
    {
        RaycastHit[] groundCheck = Physics.RaycastAll(transform.position, Vector3.down, Mathf.Infinity, controller.GroundLayer);
        foreach (RaycastHit hit in groundCheck )
        {
            // First, check to make sure the player is actively levitating above the ground right now
            if (!controller.cc.isGrounded)
            {
                controller.cc.Move(Vector3.down * controller.Gravity * Time.deltaTime);
                break;
            }
            else 
            {
                if (hit.collider.CompareTag("Stairs"))
                {
                    controller.cc.Move(Vector3.down * 100 * Time.deltaTime);
                    break;
                }
                else
                {
                    gravityAccel = 0;
                    continue;
                }
            }
        }
    }

    private void HandleDirection()
    {
        if (moveInput != Vector3.zero)
        {
            direction = controller.cam.transform.TransformDirection(moveInput);
            direction.y = 0;
        }
    }

    // Reading all of the player's current inputs and updating all associated variables
    private void HandleInputs()
    {
        Vector2 vector2 = inputs.FindAction("Move").ReadValue<Vector2>();
        moveInput = new Vector3(vector2.x, 0, vector2.y);

        runInput = inputs.FindAction("Run").IsPressed();
    }

}
