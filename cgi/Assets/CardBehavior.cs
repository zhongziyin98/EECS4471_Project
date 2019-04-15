using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class CardBehavior : MonoBehaviour
{
    public bool inHand = false; // is this card in left hand? 
    public bool pinched = false; // is this card being pinched? 

    public float displayed, targetSize; // The scale of card; value between 0f and 1f; 
    public float ddisplay = 4.0f;

    Shader std, hili;

    //public Vector3 _speed, lastPos; 

    LeapProvider provider;

    // Start is called before the first frame update
    void Start()
    {
        //lastPos = Vector3.zero; 
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        displayed = 1.0f;

        //SetTexture("gray_back"); // default texture
        SetRotation(new Vector3(-90, 0, 0));

        hili = Shader.Find("Objectify/Fresnel_Pulse");
        std = Shader.Find("Standard");
    }

    // Update is called once per frame
    void Update()
    {
        // smooth transition between open hand and close hand
        //displayed += ddisplay * Time.deltaTime;
        if (inHand)
        {
            float diff = targetSize - displayed;
            displayed += (Mathf.Sign(diff) * ddisplay * Time.deltaTime);


            GetComponent<Rigidbody>().isKinematic = true;
        }
        else if(pinched){
            GetComponent<Rigidbody>().isKinematic = true;
            displayed = 1.0f;
        }
        else
        {
            displayed = 1.0f;
            GetComponent<Rigidbody>().isKinematic = false;
        }

        displayed = Mathf.Max(0.0f, Mathf.Min(1.0f, displayed)); // range control
        Debug.Log(displayed); 

        transform.localScale = new Vector3(displayed * 0.0654356f, displayed * 0.00033f, displayed * 0.1f);


        // card rel position in hand is written in DeckBehvior

        if (pinched)
        {
            GetComponent<Renderer>().material.shader = hili;

        }
        else
        {
            GetComponent<Renderer>().material.shader = std;
        }
        /*
        if (lastPos == Vector3.zero) {
            lastPos = transform.position;
        }
        //_speed = (transform.position - lastPos)/Time.deltaTime;
        //Debug.Log(_speed.ToString("F3")); 
        */
    }

    
    public void SetScale(float val) {
        targetSize = val; 
    }

    public void SetTexture(string name)
    {
        Renderer ren = gameObject.GetComponent<Renderer>();
        Texture t = Resources.Load("cardface/" + name) as Texture;
        ren.material.mainTexture = t;
        Debug.Log("cardface/" + name);
    }

    public void SetRotation(Vector3 rot)
    {
        transform.eulerAngles = rot;

    }
}
