using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSwipeGesture : GestureBase
{

    public EHand m_Hand;
    //public EDirection m_Direction;
    [Range(0.1f, 6.0f)]
    public float m_VelocityThreshold = 1.5f;
    public float m_CooldownTime = 0.2f;
    float m_CoolDownLeft = 0.0f;

    float timeGap = 1f;
    float timeLeft = 0.0f;
    
    bool swipeLeft = false;
    bool gapLeft = false;
    float ctr = 0.0f;

    void Start()
    {

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

        if (timeLeft > 0.0f)
        {
           timeLeft -= Time.deltaTime;
            if (timeLeft < 0.0f)
            {
                timeLeft = 0.0f;
            }
        }

        if (gapLeft == true)
        {
            ctr += Time.deltaTime;
            if (ctr > 2.0f)
            {
                gapLeft = false;
                ctr = 0.0f;
            }
        }
     //   Debug.Log(timeLeft);
    }

    bool IsSwiping(ref EDirection a_swipeDirection)
    {
        DetectionManager.DetectionHand detectHand = DetectionManager.Get().GetHand(m_Hand);

        Vector3 velocity = detectHand.GetVelocity();

        velocity = Camera.main.transform.InverseTransformDirection(velocity);

        if (velocity.x >= m_VelocityThreshold) //right
        {
            a_swipeDirection = EDirection.eRight;
            return true;
        }
        else if (velocity.x <= -m_VelocityThreshold)//left
        {
            a_swipeDirection = EDirection.eLeft;
            return true;
        }
        else if (velocity.y >= m_VelocityThreshold) //up
        {
            a_swipeDirection = EDirection.eUpwards;
            return true;
        }
        else if (velocity.y <= -m_VelocityThreshold) //down
        {
            a_swipeDirection = EDirection.eDownwards;
            return true;
        }
        else if (velocity.z >= m_VelocityThreshold) //forward
        {
            a_swipeDirection = EDirection.eOutwards;
            return true;
        }
        else if (velocity.z <= -m_VelocityThreshold) //back
        {
            a_swipeDirection = EDirection.eInWards;
            return true;
        }
        return false;
    }

    public override bool Detected()
    {

        if (DetectionManager.Get().IsHandSet(m_Hand) && m_CoolDownLeft <= 0.0f)
        {
            EDirection swipeDir = EDirection.eRight;

            if (IsSwiping(ref swipeDir))
            {
                if (swipeDir == EDirection.eLeft)
                {
                    swipeLeft = true;

                    if (gapLeft == false)
                    {
                        timeLeft = timeGap;
                        gapLeft = true;
                    }            
                }
                if (swipeLeft && timeLeft > 0.1f && timeLeft < 0.5f )
                {
                    gapLeft = false;

                    if (swipeDir == EDirection.eRight)
                    {
                        swipeLeft = false;
                        m_CoolDownLeft = m_CooldownTime;
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
