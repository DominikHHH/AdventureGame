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

    // Camera Position States
    public GameObject[] StateCameras;


    // Object references
    Camera cam;
    CinemachineBrain camBrain;
    CinemachineVirtualCamera currentVirtualCam;

    private void Awake()
    {
        cam = Camera.main;
        camBrain = GetComponent<CinemachineBrain>();
        currentVirtualCam = FindObjectOfType<CinemachineVirtualCamera>().transform.parent.GetComponent<CinemachineVirtualCamera>();
    }

    public void ChangeAnchor(int cam_id)
    {
        for (int i = 0; i < StateCameras.Length; i++)
        {
            if (i == cam_id)
            {
                StateCameras[i].SetActive(true);
            }
            else
            {
                StateCameras[i].SetActive(false);
            }
        }
    }

    // Set the transition speed between virtual cameras
    public void ChangeSpeed(float speed)
    {
        camBrain.m_DefaultBlend.m_Time = speed;
    }

    // Rotate the camera by a set "scale" value
    public void RotateCamera(float rotScale)
    {
        currentVirtualCam.VirtualCameraGameObject.transform.eulerAngles += new Vector3(0, rotScale, 0);
    }
}
