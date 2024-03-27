using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class interactionScript : MonoBehaviour
{
    public bool canInteract = true;
    public bool inRange = false;
    public string interactableObj;
    public GameObject snufkinModel; // Reference to your snufkinModel object
    public Transform PositionEnterShop; // Reference to your snufkinModel object
    public Transform PositionExitShop;


    void Start()
    {
        CharacterController cc = snufkinModel.GetComponent<CharacterController>();
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

                    case "ShopEnter":
                        Debug.Log("Enter");
                        Debug.Log(PositionEnterShop.position);
                        Debug.Log(snufkinModel.transform.position);

                        // Disable the CharacterController, teleport the character, then re-enable the CharacterController
                        CharacterController cc = snufkinModel.GetComponent<CharacterController>();
                        if (cc != null)
                        {
                            cc.enabled = false;
                            snufkinModel.transform.position = PositionEnterShop.position; // Use global position
                            cc.enabled = true;
                        }

                        Debug.Log(PositionEnterShop.position);
                        Debug.Log(snufkinModel.transform.position);
                        break;

                    case "ShopExit":
                        Debug.Log("Enter");
                        Debug.Log(PositionExitShop.position);
                        Debug.Log(snufkinModel.transform.position);

                        // Disable the CharacterController, teleport the character, then re-enable the CharacterController
                        CharacterController cc2 = snufkinModel.GetComponent<CharacterController>();
                        if (cc2 != null)
                        {
                            cc2.enabled = false;
                            snufkinModel.transform.position = PositionExitShop.position; // Use global position
                            cc2.enabled = true;
                        }

                        Debug.Log(PositionExitShop.position);
                        Debug.Log(snufkinModel.transform.position);
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
