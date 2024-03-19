using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeScript : MonoBehaviour
{
    public Transform player, parentObj, cam;
    public GameObject woodLog;
    public List<GameObject> Interactables = new List<GameObject>();

    public float pickUpRange, interactionRange;

    private BoxCollider coll;
    private bool AxePickup = false;
    private Transform pickUpUi;


    private void Start()
    {
    }

    private void Update()
    {
        CheckPickUp();

    }

    private void CheckPickUp()
    {
        Vector3 distanceToPlayer = player.position - Interactables[0].transform.position;

        for (int i = 0; i < Interactables.Count; i++)
        {
            if (Interactables[i].tag == "Axe" && AxePickup == false)
            {
                pickUpUi = Interactables[i].transform.GetChild(0);
                if (distanceToPlayer.magnitude <= pickUpRange)
                {
                    test(Interactables[i], pickUpUi);
                }
                else
                {
                    pickUpUi.gameObject.SetActive(false);
                }

            }
        }
    }

    private void test(GameObject Interactable, Transform Pickupui)
    {
        Pickupui.gameObject.SetActive(true);
        Pickupui.rotation = cam.rotation;
        if (Input.GetKeyDown(KeyCode.E))
        {
            coll = Interactable.GetComponent<BoxCollider>();
            coll.enabled = false;
            Pickupui.gameObject.SetActive(false);
            Interactable.transform.localPosition = Vector3.zero;
            Interactable.transform.SetParent(parentObj);
            Interactable.transform.localPosition = Vector3.zero;
            Interactable.transform.localRotation = Quaternion.identity;
            AxePickup = true;
        }
        
    }

}
