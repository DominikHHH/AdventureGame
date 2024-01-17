using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    //*---------------------------------------------*
    //
    //  The player's main camera moving code
    //
    //*---------------------------------------------*

    // Object references
    Camera cam;
    CinemachineVirtualCamera virtualCam;

    private void Awake()
    {
        cam = Camera.main;
        virtualCam = FindObjectOfType<CinemachineVirtualCamera>().transform.parent.GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Rotate the camera by a set "scale" value
    public void RotateCamera(float rotScale)
    {
        virtualCam.VirtualCameraGameObject.transform.eulerAngles += new Vector3(0, rotScale, 0);
    }
}
