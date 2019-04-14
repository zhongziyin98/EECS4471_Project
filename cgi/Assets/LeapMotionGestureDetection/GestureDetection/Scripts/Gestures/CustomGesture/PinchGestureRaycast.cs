using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchGestureRaycast : GestureBase
{

    public EHand m_Hand;
    DetectionManager.DetectionHand m_DetectHand;
    public GameObject parentObject;
    //public GameObject testObject;
    Vector3 vector;

    public GameObject deck;

    public GameObject pinching = null;  // the card being pinched in hand

    void Start()
    {
        //testObject = GameObject.Find("Card");
    }

    void Update()
    {
        parentObject = GameObject.Find("R_Palm");
        
    }



    public void onGestureEnd() {
        if (pinching == null) {
            return; 
        }
        CardBehavior cb = pinching.GetComponent<CardBehavior>();
        cb.pinched = false;

        pinching.transform.parent = null; 
        pinching = null; 

        //TBD: after release a card, 
    }

    public void onGestureStay()
    {
        if (DetectionManager.Get().IsHandSet(m_Hand))
        {
            // Detect index finger
            m_DetectHand = DetectionManager.Get().GetHand(m_Hand);
            EFinger finger = EFinger.eThumb + 1;

            // Do raycast here
            if (DetectionManager.Get().GetHand(m_Hand).IsPinching())
            {

                RaycastHit hit;

                // Draw ray
                Debug.DrawRay(m_DetectHand.GetFinger(finger).GetTipPosition(), m_DetectHand.GetFinger(finger).GetFingerDirection() * 1000, Color.white);

                if (pinching != null)
                {
                    return;
                }

                // Draw ray for palm instead
                //Debug.DrawRay(DetectionManager.Get().GetHand(m_Hand).GetHandPosition(), transform.TransformDirection(Vector3.forward) * 1000, Color.white);

                if (Physics.Raycast(m_DetectHand.GetFinger(finger).GetTipPosition(), m_DetectHand.GetFinger(finger).GetFingerDirection(), out hit))
                {
                    if (hit.collider.tag == "Card")
                    {
                        Debug.Log("YEET");
                        //hit.collider.gameObject.transform.parent = parentObject.transform;
                        /*
                        testObject.transform.parent = parentObject.transform;
                        vector = parentObject.transform.position;
                        vector.z += 0.25f;
                        */

                        GameObject go = hit.collider.gameObject;
                        CardBehavior cb = go.GetComponent<CardBehavior>();
                        DeckBehavior db = deck.GetComponent<DeckBehavior>();
                        if (db.cardsInHand.Contains(cb)) // the card pinched is in hand
                        {
                            db.HandToPinch(go);
                        }
                        else // the card pinched is in wild
                        {
                            cb.pinched = true;
                        }
                        

                        go.transform.parent = parentObject.transform;

                        pinching = go;

                        //vector = testObject.transform.position - parentObject.transform.position; 
                        //testObject.transform.position = vector;
                        //testObject.transform.position = parentObject.transform.position + translateVector;
                        //hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            } // End raycast
            
        }

    }

    
    public override bool Detected()
    {

        return DetectionManager.Get().GetHand(m_Hand).IsPinching();
        //return false;
    }
    
}
