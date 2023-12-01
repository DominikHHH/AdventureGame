using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //  A global script for tweaking player physics and for other objects to retreive info on other components more easily
    
    [Header("Player Movement")]
    public float WalkSpeed;
    public float RunSpeed;
    public float Acceleration;

    [Header("Components")]
    public Player player;
    public PlayerStateMachine stateMachine;

    public Collider col;
    public Rigidbody rb;
    public MeshRenderer mr;

    public Camera cam;

    private void Awake()
    {
        // Initialising all components
        player = GetComponent<Player>();
        stateMachine = GetComponent<PlayerStateMachine>();

        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        mr = transform.GetChild(0).GetComponent<MeshRenderer>();

        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
