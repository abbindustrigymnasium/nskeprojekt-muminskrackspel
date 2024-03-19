using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionScript : MonoBehaviour
{
    public bool canInteract = true;
    public bool inRange = false;
    public string interactableObj;

    void Start()
    {

    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (interactableObj)
                {
                    case "log":
                        Debug.Log("LOG");
                        break;

                    case "axe":
                        Debug.Log("AXE");
                        break;

                    case "shopNPC":
                        //kod
                        break;
                }
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        inRange = true;
        interactableObj = coll.tag;
    }

    void OnTriggerExit(Collider coll)
    {
        inRange = false;
        
    }
}
