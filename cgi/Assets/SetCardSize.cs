using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity; 

public class SetCardSize : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAllCardsSize(float v) {
        foreach (GameObject cc in GameObject.FindGameObjectsWithTag("Card")) {
            CardBehavior cb = cc.GetComponent<CardBehavior>();
            cb.SetDDisplay(v); 
        }
    }

}
