using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionScript : MonoBehaviour
{
    public bool canInteract = true;
    public bool inRange = false;
    public Collider interactableObj;
    public Transform test;
    public GameObject iGO;
    public bool hasAxe = false;

    void Start()
    {

    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(interactableObj != null)
                {
                    iGO = interactableObj.gameObject;
                    switch (interactableObj.tag)
                    {
                        case "log":
                            if (hasAxe)
                            {
                                Destroy(iGO);
                            }
                            else
                            {
                                //säg att man inte kan gå dit utan yxan
                            }
                            break;

                        case "axe":
                            iGO.GetComponent<Collider>().enabled = false;
                            iGO.transform.SetParent(test);
                            iGO.transform.localPosition = Vector3.zero;
                            iGO.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                            hasAxe = true;
                            break;

                        case "shopNPC":
                            //kod
                            break;
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        inRange = true;
        interactableObj = coll;
    }

    void OnTriggerExit(Collider coll)
    {
        inRange = false;
        
    }
}
