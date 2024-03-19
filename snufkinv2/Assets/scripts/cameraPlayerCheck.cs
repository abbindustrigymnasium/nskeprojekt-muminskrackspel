using System.Collections;
using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class cameraPlayerCheck : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform TargetTrans;
    [SerializeField] private Transform PlayerTrans;
    [SerializeField] private Transform WaypointIndicator;
    [SerializeField] private float ScreenBorder = 10;

    private Vector3 targetScreenPos;
    private Vector3 playerScreenPos;

    void Start()
    {
        if (TargetTrans == null) Debug.LogError("Target referende is empty");
    }

    void Update()
    {
        //if (TargetTrans) return;

        //playerScreenPos = cam.WorldToScreenPoint(PlayerTrans.position);
        //targetScreenPos = cam.WorldToScreenPoint(TargetTrans.position);

        //bool isOffScreen = targetScreenPos.x <= ScreenBorder || targetScreenPos.x >= Screen.width || targetScreenPos.y <= ScreenBorder || targetScreenPos.y >= Screen.height;
        //if (isOffScreen)
        //{
        //    Debug.Log("Off-Screen");
        //}
        //else
        //{
        //    Debug.Log("On-Screen");
        //}

        playerScreenPos = cam.WorldToScreenPoint(PlayerTrans.position);
        bool isOffScreen = Mathf.Abs(playerScreenPos.x) >= Screen.width || Mathf.Abs(playerScreenPos.y) >= Screen.height;
        if (isOffScreen)
        {
            Debug.Log("Off-Screen");
        }
    }
}
