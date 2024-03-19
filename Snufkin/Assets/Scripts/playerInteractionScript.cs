using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractionScript : MonoBehaviour
{
    //void Update()
    //{
    //    Vector3 fwd = transform.TransformDirection(Vector3.forward);

    //    if (Physics.Raycast(transform.position, fwd, 10))
    //    {
    //        print("There is something in front of the object!");

    //    }
    //}
    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("Enter");
    }
    void OnCollisionExit(Collision coll)
    {
        Debug.Log("Exit");
    }
    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Trigger enter");
    }
    void OnTriggerExit(Collider coll)
    {
        Debug.Log("Trigger exit");
    }
}
