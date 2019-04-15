using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : GestureBase
{
    public EHand m_Hand;
    DetectionManager.DetectionHand m_DetectHand;
    public float DeactivateDistance = .01f; //meters

    FingerExtendedDetails m_GestureDetail;
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

    }

    public override bool Detected()
    {
        EFinger indexFinger = EFinger.eThumb + 1;
        EFinger middleFinger = EFinger.eThumb + 2;
        m_DetectHand = DetectionManager.Get().GetHand(m_Hand);

        if (m_DetectHand.IsSet())
        {
            if (m_DetectHand.CheckWithDetails(m_GestureDetail))
            {
                //Debug.DrawRay(m_DetectHand.GetFinger(indexFinger).GetTipPosition(), m_DetectHand.GetFinger(indexFinger).GetFingerDirection() * 1000, Color.white);
                var indexTipPosition = m_DetectHand.GetFinger(indexFinger).GetTipPosition();
                var middleTipPosition = m_DetectHand.GetFinger(middleFinger).GetTipPosition();
                float distance = Vector3.Distance(indexTipPosition, middleTipPosition);

                if (distance < DeactivateDistance)
                    return true;

            }
        }

        return false;
    }


}
