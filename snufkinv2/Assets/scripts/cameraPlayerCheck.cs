using System.Collections;
using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class cameraPlayerCheck : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform TargetTrans;
    [SerializeField] private Transform PlayerTrans;

    private Vector3 targetScreenPos;
    private Vector3 playerScreenPos;

    public List<Transform> cameraPos = new List<Transform>();
    private int currentCameraIndex = 0;

    void Start()
    {
        if (TargetTrans == null) Debug.LogError("Target referende is empty");
        Debug.Log("Width" + Screen.width + "Height" + Screen.height);

    }

    void Update()
    {
        Vector3 viewportPoint = cam.WorldToViewportPoint(PlayerTrans.position);
        if (viewportPoint.x < 0 || viewportPoint.x > 1)
        {
            if (viewportPoint.x < 0)
            {
                if (currentCameraIndex != 1)
                {
                    currentCameraIndex = 1;
                    MoveCameraToPosition();
                }
            }
            else
            {
                if (currentCameraIndex != 0)
                {
                    currentCameraIndex = 0;
                    MoveCameraToPosition();
                }
            }
        }
    }

    void MoveCameraToPosition()
    {
        if (currentCameraIndex >= 0 && currentCameraIndex < cameraPos.Count)
        {
            cam.transform.position = cameraPos[currentCameraIndex].position;
        }
        else
        {
            Debug.LogError("Invalid camera position index: " + currentCameraIndex);
        }
    }
}