using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GestureBase
{

    public EHand m_Hand;

    FingerExtendedDetails m_GestureDetail;

    float m_CooldownTime = 0.2f;
    float m_CoolDownLeft = 0.0f;

    void Start()
    {
        m_GestureDetail.bThumbExtended = true;
        m_GestureDetail.bIndexExtended = true;
        m_GestureDetail.bMiddleExtended = false;
        m_GestureDetail.bRingExtended = false;
        m_GestureDetail.bPinkeyExtended = false;
    }

    void Update()
    {
        if (m_CoolDownLeft > 0.0f)
        {
            m_CoolDownLeft -= Time.deltaTime;
            if (m_CoolDownLeft < 0.0f)
            {
                m_CoolDownLeft = 0.0f;
            }
        }
    }

    public override bool Detected()
    {
        DetectionManager.DetectionHand detectHand = DetectionManager.Get().GetHand(m_Hand);

        if (detectHand.IsSet())
        {
            if (detectHand.CheckWithDetails(m_GestureDetail))
            {
                var rot = detectHand.GetRotation();

               // Debug.Log(rot);

                m_CoolDownLeft = m_CooldownTime;
                return true;
            }
        }

        return false;
    }
}
