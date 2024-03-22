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
    CinemachineVirtualCamera currentVirtualCam;

    private void Awake()
    {
        cam = Camera.main;
        currentVirtualCam = FindObjectOfType<CinemachineVirtualCamera>().transform.parent.GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

    // Update is called once per frame
    void Update()
    {
        
    }

    // Rotate the camera by a set "scale" value
    public void RotateCamera(float rotScale)
    {
        currentVirtualCam.VirtualCameraGameObject.transform.eulerAngles += new Vector3(0, rotScale, 0);
    }
}
