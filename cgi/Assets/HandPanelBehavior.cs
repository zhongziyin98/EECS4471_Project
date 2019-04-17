using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPanelBehavior : MonoBehaviour
{
    
    public static Vector3 DEFAULT_SIZE = new Vector3(0.6f, 0.6f, 0.6f);

    public float size = 1.0f; 
    public float targetSize = 1.0f; 

    LeapProvider provider;
    Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }

    // Update is called once per frame
    void Update()
    {
        //position
        Frame frame = provider.CurrentFrame;

        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsLeft)
            {
                vector = hand.PalmPosition.ToVector3();
                vector.x += 0.22f;
                transform.position = vector;
                //Debug.Log(vector.ToString());
            }
        }

        //size
        size = size * 0.8f + targetSize * 0.2f; 
        transform.localScale = DEFAULT_SIZE * size; 
    }

    public void SetSize(float val){
        targetSize = val; 
    }
}
