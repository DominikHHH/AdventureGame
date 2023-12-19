using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //*---------------------------------------------*
    //
    //  A global script for tweaking player physics and for other objects to retreive info on other components more easily
    //
    //*---------------------------------------------*

    [Header("Player Movement")]
    public LayerMask GroundLayer;
    public float Gravity;
    [Space(10)]
    public float WalkSpeed;
    public float RunSpeed;
    public float Acceleration;

    [Header("Components")]
    public Player player;
    public PlayerStateMachine stateMachine;

    public CapsuleCollider col;
    public CharacterController cc;
    public MeshRenderer mr;

    public Camera cam;

    private void Awake()
    {
        // Initialising all components
        player = GetComponent<Player>();
        stateMachine = GetComponent<PlayerStateMachine>();

        col = GetComponent<CapsuleCollider>();
        cc = GetComponent<CharacterController>();
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
