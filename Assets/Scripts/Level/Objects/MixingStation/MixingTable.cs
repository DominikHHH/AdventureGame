using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MixingTable : MonoBehaviour
{
    //*---------------------------------------------*
    //
    //  The table where all ingredients will need to be brought over one-by-one
    //
    //*---------------------------------------------*

    public PlayableDirector cutscene;
    public List<GameObject> RequiredObjects = new List<GameObject>();
    List<GameObject> collectedObjects = new List<GameObject>();

    MixingSequence sequence;
    Player player;
    CameraController camCon;

    private void Awake()
    {
        sequence = FindObjectOfType<MixingSequence>();
        sequence.gameObject.SetActive(false);
        player = FindObjectOfType<Player>();
        camCon = FindObjectOfType<CameraController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (RequiredObjects.Contains(other.gameObject))
        {
            if (other.transform.parent != null)
            {
                other.transform.parent.DetachChildren();
            }
            collectedObjects.Add(other.gameObject);
            other.GetComponent<PickupObject>().Deactivate();

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
        sequence.gameObject.SetActive(true);
        cutscene.Play();
    }
}
