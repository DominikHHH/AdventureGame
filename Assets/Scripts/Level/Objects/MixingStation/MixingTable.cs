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
        
    }
}
