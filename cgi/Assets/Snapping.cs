using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : GestureBase
{
    public EHand m_Hand;
    DetectionManager.DetectionHand m_DetectHand;
    public float DeactivateDistance = .02f; //meters

    FingerExtendedDetails m_GestureDetail;
    float timeGap = 0.5f;
    float gapLeft = 0.0f;

    bool snap = false;
    // Start is called before the first frame update
    void Start()
    {
        m_GestureDetail.bThumbExtended = true;
        m_GestureDetail.bIndexExtended = true;
        m_GestureDetail.bMiddleExtended = true;
        m_GestureDetail.bRingExtended = false;
        m_GestureDetail.bPinkeyExtended = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gapLeft > 0.0f)
        {
            gapLeft -= Time.deltaTime;
            if (gapLeft < 0.0f)
            {
                gapLeft = 0.0f;
            }
        }
        else if (gapLeft == 0.0f)
            snap = false;
    }

    public override bool Detected()
    {
        EFinger thumbFinger = EFinger.eThumb;
        EFinger middleFinger = EFinger.eThumb + 2;
        m_DetectHand = DetectionManager.Get().GetHand(m_Hand);

        if (m_DetectHand.IsSet())
        {
            if (m_DetectHand.CheckWithDetails(m_GestureDetail))
            {
                //Debug.Log("ok");
                //Debug.DrawRay(m_DetectHand.GetFinger(indexFinger).GetTipPosition(), m_DetectHand.GetFinger(indexFinger).GetFingerDirection() * 1000, Color.white);
                snap = true;
                /*var thumbTipPosition = m_DetectHand.GetFinger(thumbFinger).GetTipPosition();
                var middleTipPosition = m_DetectHand.GetFinger(middleFinger).GetTipPosition();
                float distance = Vector3.Distance(thumbTipPosition, middleTipPosition);
                Debug.Log(distance);
                if (distance < DeactivateDistance)
                    return true;*/
                gapLeft = timeGap;

            }

            //Debug.Log(gapLeft);
            if (snap&& gapLeft>0.0f)
            {

                var thumbTipPosition = m_DetectHand.GetFinger(thumbFinger).GetTipPosition();
                var middleTipPosition = m_DetectHand.GetFinger(middleFinger).GetTipPosition();
                float distance = Vector3.Distance(thumbTipPosition, middleTipPosition);
                // Debug.Log(distance);
                if (distance < 0.02f)
                {
                   // Debug.Log("snap");
                    return true;
                }


            }
        }

        return false;
    }


}
