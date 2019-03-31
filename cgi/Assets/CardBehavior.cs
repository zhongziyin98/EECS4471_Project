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

        SetTexture("1S");
        SetRotation(new Vector3(-90, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(displayed*0.654356f, displayed*0.0033f, displayed*1.0f);

        timer += Time.deltaTime;


    }

    public void SetTexture(string name)
    {
        var ren = gameObject.GetComponent<Renderer>();
        Texture t = Resources.Load("cardface/" + name) as Texture;
        ren.material.mainTexture = t;
        Debug.Log("cardface/" + name);
    }

    public void SetRotation(Vector3 rot)
    {
        transform.eulerAngles = rot;

    }
}
