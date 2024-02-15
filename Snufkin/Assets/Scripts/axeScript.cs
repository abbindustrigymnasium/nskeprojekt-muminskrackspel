using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeScript : MonoBehaviour
{
    public BoxCollider coll;
    public Transform player, parentObj, cam;
    public GameObject pickUpUi, woodLog;

    public float pickUpRange, interactionRange;
    private bool axePickedUp = false;

    private void Start()
    {
        pickUpUi.SetActive(false);
    }

    private void Update()
    {
        CheckPickUp();
        CheckLog();

    }

    private void CheckPickUp()
    {
        Vector3 distanceToPlayer = player.position - transform.position;

        if (distanceToPlayer.magnitude <= pickUpRange && axePickedUp == false)
        {
            pickUpUi.SetActive(true);
            pickUpUi.transform.rotation = cam.rotation;
            if (Input.GetKeyDown(KeyCode.E))
            {
                coll.enabled = false;
                pickUpUi.SetActive(false);
                transform.localPosition = Vector3.zero;
                transform.SetParent(parentObj);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                axePickedUp = true;

            }
        }
        else
        {
            pickUpUi.SetActive(false);
        }
    }

    private void CheckLog()
    {
        Vector3 distanceToLog = player.position - woodLog.transform.position;

        if (distanceToLog.magnitude <= interactionRange && axePickedUp)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Hejsan");
            }
        }
    }

}
