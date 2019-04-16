using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GestureBase
{

    public EHand m_Hand;

    FingerExtendedDetails m_GestureDetail;

    float m_CooldownTime = 0.4f;
    float m_CoolDownLeft = 0.0f;

    float stayTime = 3f;
    float stayLeft = 0.0f;

    bool gunBegin = false;

    bool timeBegin = false;
    float timeElapsed = 0.0f;
    float timeReset = 0.0f;

    GameObject prefab;

    void Start()
    {
        m_GestureDetail.bThumbExtended = true;
        m_GestureDetail.bIndexExtended = true;
        m_GestureDetail.bMiddleExtended = false;
        m_GestureDetail.bRingExtended = false;
        m_GestureDetail.bPinkeyExtended = false;

        prefab = Resources.Load("bullet") as GameObject;
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

        if (timeBegin)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= 3.0f)
            {
                timeElapsed = timeReset;
                timeBegin = false;
            }
        }
        //Debug.Log(timeElapsed);
    }

    public override bool Detected()
    {
        DetectionManager.DetectionHand detectHand = DetectionManager.Get().GetHand(m_Hand);

        EFinger indexFinger = EFinger.eThumb+1;

        if (detectHand.IsSet())
        {
            if (detectHand.CheckWithDetails(m_GestureDetail))
            {
                var rot = detectHand.GetRotation();

               if (timeBegin == false)
                {
                    timeBegin = true;
                }

                //Debug.DrawRay(detectHand.GetFinger(indexFinger).GetTipPosition(), detectHand.GetFinger(indexFinger).GetFingerDirection() * 3.0f, Color.white);
                //Debug.DrawRay(DetectionManager.Get().GetHand(m_Hand).GetHandPosition(), detectionHand.GetHandAxis(m_HandAxis) * 1000, Color.red);


                //Debug.Log(stayTime);


                if (rot.x > 0.25f && m_CoolDownLeft <= 0.0f && stayTime == 0.0f)
                {
                    m_CoolDownLeft = m_CooldownTime;
                    GameObject projectile = Instantiate(prefab) as GameObject;
                    var spawn = detectHand.GetFinger(indexFinger).GetTipPosition();

                    projectile.transform.position = spawn;
                    Rigidbody rb = projectile.GetComponent<Rigidbody>();
                    //var di = detectHand.GetFinger(indexFinger).GetFingerDirection();
                    //di.y -= 0.6f;
                    // di.z += 0.3f;
                    //di.x += 0.2f;
                    //rb.AddForce(Camera.main.transform.forward * 20f, ForceMode.VelocityChange);
                    rb.velocity = Vector3.forward * 8;
                }


                return true;
            }
            
        }

        return false;
    }
}
