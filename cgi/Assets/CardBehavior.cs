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

    public static Vector3 DEFAULT_SIZE = new Vector3(0.0654356f, 0.00033f, 0.1f);
    public Texture t; 
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
        Renderer ren = GetComponent<Renderer>();
        ren.material.EnableKeyword ("_NORMALMAP");
        ren.material.EnableKeyword ("_METALLICGLOSSMAP");
    }

    // Update is called once per frame
    void Update()
    {
        // smooth transition between open hand and close hand
        //displayed += ddisplay * Time.deltaTime;
        if (inHand)
        {
            //float diff = targetSize - displayed;
            //displayed += (Mathf.Sign(diff) * ddisplay * Time.deltaTime);
            displayed = displayed * 0.8f + targetSize * 0.2f; 


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

        transform.localScale = DEFAULT_SIZE * displayed;  //new Vector3(displayed * 0.0654356f, displayed * 0.00033f, displayed * 0.1f);


        // card rel position in hand is written in DeckBehvior
        Renderer ren = GetComponent<Renderer>();
        if (pinched)
        {

            ren.material.shader = hili;
            ren.material.SetTexture("_Diffuse", t);

            Renderer cren = gameObject.transform.GetChild(0).GetComponent<Renderer>(); 
            cren.material.shader = hili;
            Texture back = Resources.Load("cardface/cardback") as Texture;
            cren.material.SetTexture("_Diffuse", back);
        }
        else
        {
            ren.material.shader = std;
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material.shader = std;
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
        t = Resources.Load("cardface/" + name) as Texture;
        ren.material.mainTexture = t;

        ren.material.shader = std; 
        //ren.material.SetTexture("_Diffuse", t);
        //ren.material.mainTexture = t;
    }

    public void SetRotation(Vector3 rot)
    {
        transform.eulerAngles = rot;

    }
}
