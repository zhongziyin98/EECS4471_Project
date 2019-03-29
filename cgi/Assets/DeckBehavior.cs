﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBehavior : MonoBehaviour
{

    public GameObject cardsInHand = new GameObject[60]; // max hand size 60
    public string cardsInDeck = new string[60]; // deck size; stores names of cards
    public ArrayList cardsInHand = new ArrayList(); // max hand size 60
    public ArrayList cardsInDeck = new ArrayList(); // deck size; stores names of cards

    // Start is called before the first frame update
    void Start()
    {
        InitiateDeck(); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateDeck() {
        
        for (int i = 1; i < 13; i++)
        {
            cardsInDeck.Add(i + "C");
            cardsInDeck.Add(i + "D");
            cardsInDeck.Add(i + "H");
            cardsInDeck.Add(i + "S");
        }

        Shuffle(); 
        
    }

    public void Shuffle() {
        
        for (int i = 1; i < cardsInDeck.Count; i++)
        {
            float n = cardsInDeck.Count*1.0; 
            int ran = Mathf.RoundToInt(Random.Range(0.0f, n));
            string a = cardsInDeck[i];
            string b = cardsInDeck[ran];
            string tmp = a;
            a = b;
            b = tmp; 
        }
        
    }

}
