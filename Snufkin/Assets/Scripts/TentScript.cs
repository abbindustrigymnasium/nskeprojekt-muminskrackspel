using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentScript : MonoBehaviour
{
    public BoxCollider coll;
    public Transform player, cam;
    public GameObject InteractUi;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;



    }
}
