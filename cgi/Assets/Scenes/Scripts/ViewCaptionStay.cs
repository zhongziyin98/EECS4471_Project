using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCaptionStay : MonoBehaviour
{
    public GameObject obj;
    public GameObject handObject;
    Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.Find("Caption");
    }

    // Update is called once per frame
    void Update()
    {
        handObject = GameObject.Find("R_Palm");
        vector = handObject.transform.position;
        vector.y += 0.2f;
        vector.x += 0.2f;
    }

    public void ViewStay()
    {
        //transform.parent = handObject.transform;
        transform.position = vector;
        obj.gameObject.SetActive(true);
    }

    public void ViewEnd()
    {
        obj.gameObject.SetActive(false);
    }
}