using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class CardBehavior : MonoBehaviour
{
    public bool inHand = false; 
    public float displayed; // The scale of card; value between 0f and 1f; 
    public float ddisplay = 2.0f; 

    LeapProvider provider;

    // Start is called before the first frame update
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        displayed = 1.0f;

        //SetTexture("gray_back"); // default texture
        SetRotation(new Vector3(-90, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        // smooth transition between open hand and close hand
        displayed += ddisplay * Time.deltaTime;
        if (inHand)
        {

            GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            displayed = 1.0f;
            GetComponent<Rigidbody>().isKinematic = false;
        }

        displayed = Mathf.Max(0.0f, Mathf.Min(1.0f, displayed)); // range control

        transform.localScale = new Vector3(displayed * 0.654356f, displayed * 0.0033f, displayed * 1.0f);


        // card rel position in hand is written in DeckBehvior


        Frame frame = provider.CurrentFrame;

        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsLeft)
            {

            }
        }
    }
    
    public void SetDDisplay(float val) {
        ddisplay = val; 
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
