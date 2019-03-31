using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class CardBehavior : MonoBehaviour
{

    public bool inHand; // is the card in hand? 
    public float displayed; // The scale of card; value between 0f and 1f; 
    public Hand attachedTo;

    public float timer; //the moving procedure from deck to hand; 



    // Start is called before the first frame update
    void Start()
    {
        inHand = false;
        displayed = 1.0f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(displayed*0.654356f, displayed*0.0033f, displayed*1.0f);

        timer += Time.deltaTime;


    }
}
