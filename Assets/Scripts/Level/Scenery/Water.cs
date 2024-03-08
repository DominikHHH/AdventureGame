using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    //*---------------------------------------------*
    //
    //  Water surface bobbing for when the player enters the water
    //
    //*---------------------------------------------*

    public float WaterForce;
    public float BounceRange;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(UnityEngine.Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.currentGravity -= WaterForce;
            player.currentGravity = Mathf.Clamp(player.currentGravity, -BounceRange, BounceRange);
        }
        else if (other.attachedRigidbody != null)
        {
            Rigidbody rb = other.attachedRigidbody;
            rb.AddForce(new Vector3(0, WaterForce, 0));
            rb.velocity = new Vector3(0, Mathf.Clamp(rb.velocity.y, -BounceRange, BounceRange), 0);
        }
    }
}
