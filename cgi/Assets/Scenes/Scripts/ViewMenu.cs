using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMenu : MonoBehaviour
{
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
        Frame frame = provider.CurrentFrame;

        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsLeft)
            {
                vector = hand.PalmPosition.ToVector3();
                vector.y += 0.2f;
                transform.position = vector;
                //Debug.Log(vector.ToString());
            }
        }
    }
}
