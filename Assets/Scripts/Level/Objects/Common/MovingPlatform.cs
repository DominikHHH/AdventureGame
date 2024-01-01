using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //*---------------------------------------------*
    //
    //  A moving platform that moves back-and-forth between two points
    //
    //*---------------------------------------------*

    public float MoveSpeed; // How quickly the platform moves between its two target points
    public float MovePauseTime; // For how long the platform pauses when it reaches a target point

    public Vector3 currentSpeed;

    List<Vector3> targetPoints = new List<Vector3>();
    int currentTargetPoint;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {        
        for (int i = 0; i <= transform.childCount - 1; i++)
        {
            targetPoints.Add(transform.GetChild(i).position);
        }
        currentTargetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        currentSpeed = Vector3.MoveTowards(transform.position, targetPoints[currentTargetPoint], MoveSpeed *  Time.deltaTime) - transform.position;
        transform.position += currentSpeed;
        if (transform.position == targetPoints[currentTargetPoint])
        {
            if (currentTargetPoint >= targetPoints.Count - 1) { currentTargetPoint = 0; }
            else { currentTargetPoint++; }
        }
    }

    public void MoveObject(GameObject obj)
    {
        obj.transform.position += currentSpeed;
        Debug.Log("Repositioning player");
    }
}
