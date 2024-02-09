using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeScript : MonoBehaviour
{
    public BoxCollider coll;
    public Transform player, parentObj;
    public GameObject pickUpUi;

    public float pickUpRange;

    private void Start()
    {
        pickUpUi.SetActive(false);
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickUpRange)
        {
            pickUpUi.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                coll.enabled = false;
                pickUpUi.SetActive(false);
                transform.localPosition = Vector3.zero;
                transform.SetParent(parentObj);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                this.enabled = false;
            }
        }
        else
        {
            pickUpUi.SetActive(false);
        }
    }
}
