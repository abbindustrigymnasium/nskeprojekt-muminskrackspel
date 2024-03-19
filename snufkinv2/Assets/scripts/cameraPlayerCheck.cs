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

    public List<GameObject> cameraPos = new List<GameObject>();

    void Start()
    {
        if (TargetTrans == null) Debug.LogError("Target referende is empty");
        Debug.Log("Width" + Screen.width + "Height" + Screen.height);
    }

    void Update()
    {
        playerScreenPos = cam.WorldToScreenPoint(PlayerTrans.position);
        bool isOffScreen = playerScreenPos.x >= Screen.width || playerScreenPos.y >= Screen.height || playerScreenPos.x <= 0 || playerScreenPos.y <= 0;
        if (isOffScreen)
        {
            Debug.Log("Off-Screen");
        }
    }
}
