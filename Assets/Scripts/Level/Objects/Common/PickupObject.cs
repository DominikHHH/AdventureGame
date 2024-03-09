using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    //*---------------------------------------------*
    //
    //  The base class for all pick-up-able objects in the game
    //
    //*---------------------------------------------*

    public float PickUpDistance;
    public float Weight;
    
    bool isPickedUp = false;

    Player player; // The object that we'll try to follow if we've been picked up

    MeshRenderer mesh;
    Rigidbody rb;
    SphereCollider col;

    private void Awake()
    {
        player = FindObjectOfType<Player>();

        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        col = GetComponent<SphereCollider>();
    }

    void Start()
    {
        rb.isKinematic = true;
    }

    void Update()
    {
        if (isPickedUp)
        {
            //Debug.Log(player.controller.charCon.velocity);
            if (player.pickUpInput && player.PickUpAnchor.childCount != 0)
            {
                isPickedUp = false;
                col.enabled = true;
                rb.isKinematic = false;

                player.PickUpAnchor.DetachChildren();
                rb.velocity = player.velocity;
            }
        }
        else
        {
            // Check for if the player has gotten close enough to pick up
            if (player.pickUpInput && player.PickUpAnchor.childCount == 0)
            {
                if (Vector3.Distance(rb.position, player.transform.position) <= PickUpDistance)
                {
                    isPickedUp = true;
                    col.enabled = false;
                    rb.isKinematic = true;

                    transform.position = player.PickUpAnchor.position;
                    transform.parent = player.PickUpAnchor;
                }
            }
        }
    }
}
