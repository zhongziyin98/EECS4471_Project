using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabChip : MonoBehaviour
{
    bool grab = false;
    public GameObject handObject;
    Vector3 vector;

    void Update()
    {
        handObject = GameObject.Find("R_Palm");
        vector = handObject.transform.position;
        vector.y -= 0.1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CubeTip")
        {
            grab = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CubeTip") //LoPoly Rigged Hand Right
            grab = false;
    }

    public void GrabinStart()
    {

        if (grab == true)
        {
            Debug.Log("Grab chip");

            transform.parent = handObject.transform;
            transform.position = vector;

            grab = false;
        }
    }
}
