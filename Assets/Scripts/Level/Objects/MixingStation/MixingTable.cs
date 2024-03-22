using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingTable : MonoBehaviour
{
    //*---------------------------------------------*
    //
    //  The table where all ingredients will need to be brought over one-by-one
    //
    //*---------------------------------------------*

    public List<GameObject> RequiredObjects = new List<GameObject>();
    List<GameObject> collectedObjects = new List<GameObject>();

    Player player;
    CameraController camCon;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        camCon = FindObjectOfType<CameraController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (RequiredObjects.Contains(collision.gameObject))
        {
            if (collision.transform.parent != null)
            {
                collision.transform.parent.DetachChildren();
            }
            collectedObjects.Add(collision.gameObject);
            collision.gameObject.SetActive(false);

            if (collectedObjects.Count >= RequiredObjects.Count)
            {
                if (CheckIfAllCollected())
                {
                    AllCollected();
                }
            }
        }
    }

    // Check the two object lists to see if they share the same contents, no matter their order
    bool CheckIfAllCollected()
    {
        int i = 0;
        foreach (GameObject obj in RequiredObjects) 
        { 
            if (collectedObjects.Contains(obj))
            {
                i++;
            }
        }

        if (i >= RequiredObjects.Count)
            return true;
        else 
            return false;
    }

    // Initiate mixing sequence if all required objects have been found
    void AllCollected()
    {
        player.enabled = false;
        camCon.ChangeAnchor(2);
    }
}
