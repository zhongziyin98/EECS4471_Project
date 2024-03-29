﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class DeckBehavior : MonoBehaviour
{
    public CardBehavior card;

    LeapProvider provider;

    public ArrayList cardsInHand = new ArrayList(); // all cards in hand; 
    public List<string> cardsInDeck = new List<string>(); // all cards in deck; stores names of cards


    bool enableSetSize = false; 
    float targetSize = 1.0f;

    float cardInterval = 0.1f; 

    public bool bmOn = false;

    GameObject prefab;

    bool rhombus = false;


    // Start is called before the first frame update
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;

        InitiateDeck();

        DrawCard();

        prefab = Resources.Load("magic_purple") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        RenderCardPosition();
        RenderCardSize();

    }


    public void DrawCard()
    {
        int n = cardsInDeck.Count;
        if (n <= 0)
        {
            return;
        }
        // generate a card at deck positoin
        Vector3 pos = new Vector3(0.3f, 0.11f, -2.9f);
        CardBehavior go = Instantiate(card, pos, Quaternion.identity);
        string s = cardsInDeck[n - 1]; // get and remove a card
        cardsInDeck.RemoveAt(n - 1);
        go.SetTexture(s);

        cardsInHand.Add(go);

        go.inHand = true;

        //Frame frame = provider.CurrentFrame;
        /*
        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsLeft)
            {
                go.attachedTo = hand; 
            }

        }
        */
    }

    public void RenderCardPosition()
    {
        int n = cardsInHand.Count;

        for (int i = 0; i < n; i++)
        {
            CardBehavior go = (CardBehavior)cardsInHand[i];

            float xOffset = -cardInterval * 0.5f * (n-1) + cardInterval * i;
            float zOffset = -0.0005f * i;

            //Vector3 oldPos = go.gameObject.transform.position;

            Hand h;
            //Hand h = go.attachedTo;
            Frame frame = provider.CurrentFrame;

            foreach (Hand hand in frame.Hands)
            {
                if (hand.IsLeft)
                {

                    Vector3 oldPos = go.gameObject.transform.position;

                    h = hand;
                    Vector3 hp = h.PalmPosition.ToVector3();
                    hp.y += 0.1f;
                    hp.x += xOffset;
                    hp.z += zOffset;

                    go.gameObject.transform.position = oldPos * 0.76f + hp * 0.24f;

                    //go.gameObject.transform.eulerAngles = new Vector3(-90, 0, 0);

                    if (bmOn)
                    {
                        //spinning
                        go.transform.Rotate(0, 4, 0, Space.World);
                       
                       if(go.r==false){
                            go.transform.Rotate(0, 40, 0);
                            go.r=true;
                       }

                        if (!rhombus)
                        {


                            //go.transform.Rotate(0, 40, 0);
                            
                            GameObject projectile = Instantiate(prefab) as GameObject;

                            var hp1 = h.PalmPosition.ToVector3();

                            hp1.z += 1;
                            hp1.y += 0.3f;

                            projectile.transform.position = hp1;


                            rhombus = true;

                        }
                    }
                    else if (!bmOn)
                    {
                        go.gameObject.transform.eulerAngles = new Vector3(-90, 0, 0);
                        Destroy(GameObject.Find("magic_purple(Clone)"));
                        go.r = false;
                    }
                
                }
            }

        }
        
    }

    public void RenderCardSize()
    {
        int n = cardsInHand.Count;

        for (int i = 0; i < n; i++)
        {
            CardBehavior go = (CardBehavior)cardsInHand[i];
            go.SetScale(targetSize);
        }

    }

    public void SetCardInterval(float val){
        cardInterval = val; 
    }


    public void HandToPinch(GameObject cc)
    {
        CardBehavior cb = cc.GetComponent<CardBehavior>();
        cb.inHand = false;
        cb.pinched = true;

        cardsInHand.Remove(cb);

    }


    public void InitiateDeck()
    {
        cardsInDeck.Clear();
        for (int i = 1; i <= 13; i++)
        {
            cardsInDeck.Add(i + "C");
            cardsInDeck.Add(i + "D");
            cardsInDeck.Add(i + "H");
            cardsInDeck.Add(i + "S");
            //Debug.Log(i);
        }

        Shuffle();

    }

    public void Shuffle()
    {

        for (int i = 0; i < cardsInDeck.Count; i++)
        {
            float n = (cardsInDeck.Count - 1) * 1.0f;
            int ran = Mathf.RoundToInt(Random.Range(0.0f, n));
            string a = cardsInDeck[i];
            string b = cardsInDeck[ran];
            string tmp = a;
            cardsInDeck[i] = b;
            cardsInDeck[ran] = tmp;
        }
        /*
        for (int i = 0; i < cardsInDeck.Count; i++)
        {
            string a = cardsInDeck[i];
            Debug.Log(a);
        }
        */
    }

    public void SetTargetSize(float val)
    {
        if (enableSetSize){
            targetSize = val;
        }else{
            targetSize = 0.0f; 
        }
        

    }

    public void FistOff(bool val){
        enableSetSize = val; 
    }


    public void blackMagic(bool magic)
    {
        bmOn = magic;

        if (magic == false)
        {
            rhombus = false;
        }

    }

}
