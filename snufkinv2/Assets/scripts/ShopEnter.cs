using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopEnter : MonoBehaviour
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

                    case "enter":
                        SceneManager.LoadScene("InsideShop");
                        break;

                }
            }
        }
    }

    void OnTriggerEnter(Collider ShopEnter)
    {
        inRange = true;
        interactableObj = ShopEnter.tag;
    }

    void OnTriggerExit(Collider ShopEnter)
    {
        inRange = false;

    }
}
