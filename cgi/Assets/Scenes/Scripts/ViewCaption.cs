using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCaption : MonoBehaviour
{
    public GameObject obj;

    float m_CoolDownLeft = 0.0f;
    float m_CooldownTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.Find("Caption");
    }

    // Update is called once per frame
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
        if (m_CoolDownLeft == 0.0f)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public void View()
    {
        obj.gameObject.SetActive(true);
        m_CoolDownLeft = m_CooldownTime;
        //  obj.GetComponent<Canvas>().enabled = true;
    }
}