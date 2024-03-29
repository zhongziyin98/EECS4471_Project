﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipBehavior : MonoBehaviour
{
    public bool held = false;

    bool grab = false;
    public GameObject handObject;
    Vector3 vector;
    public Rigidbody rb;

    Shader std, hili;

    // Start is called before the first frame update
    void Start()
    {
        hili = Shader.Find("Objectify/Fresnel_Pulse");
        std = Shader.Find("Standard");
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().isKinematic = held;
        if (GameObject.Find("R_Palm") != null)
        {
            handObject = GameObject.Find("R_Palm");
            vector = handObject.transform.position;
            vector.y -= 0.1f;
        }

        if (held)
        {
            GetComponent<Renderer>().materials[1].shader = hili;
            GetComponent<Renderer>().materials[2].shader = hili;
            GetComponent<Renderer>().materials[1].SetFloat("Corrective_Glow", 0);

        }
        else {
            GetComponent<Renderer>().materials[1].shader = std;
            //GetComponent<Renderer>().materials[2].shader = std;
        }



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
            //transform.position = vector;

            grab = false;
            held = true;
            rb.isKinematic = true;

        }
    }

    public void GrabinEnd()
    {
        rb.isKinematic = false;

        transform.parent = null;
        held = false; 
    }
}
