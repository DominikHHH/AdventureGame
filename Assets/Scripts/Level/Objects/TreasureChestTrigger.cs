using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestTrigger : MonoBehaviour
{
    //*---------------------------------------------*
    //
    //  If the player gets close enough, this script triggers the animations/particles for the treasure chest to appear
    //
    //*---------------------------------------------*

    public GameObject TreasureChest;
    public ParticleSystem TreasureRockParticles;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            // Start animation
            TreasureRockParticles.Play();
        }
    }
}
