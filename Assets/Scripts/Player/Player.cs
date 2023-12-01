using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //      The player's main input/collision detection code

    // Inputs
    public Vector3 inputMove;
    public bool inputRun;

    public InputActionMap inputs;

    // Components
    PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        inputMove = new Vector3(inputs.FindAction("Move").ReadValue<Vector2>().x, 0, inputs.FindAction("Move").ReadValue<Vector2>().y);
        inputRun = inputs.FindAction("Run").ReadValue<Boolean>();
    }
}
