using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private const float YMin = -50.0f;
    private const float YMax = 50.0f;

    public Transform lookAt;
    public Transform aimingPos;

    public Transform Player;
    public Movement movementScript;

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 100.0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        if (movementScript.moving)
        {
            Player.rotation = Quaternion.Lerp(Player.rotation, Quaternion.Euler(0, currentX, 0), 0.1f);
        }
    }

    void LateUpdate()
    {
        currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);
        //if (!GunScript.isAiming)
        //{
            transform.position = lookAt.position + rotation * Direction;
            transform.LookAt(lookAt.position);
        //}
        //else if (GunScript.isAiming)
        //{
        //    transform.position = aimingPos.position + rotation * Direction;
        //    transform.LookAt(aimingPos.position);
        //}

    }
}