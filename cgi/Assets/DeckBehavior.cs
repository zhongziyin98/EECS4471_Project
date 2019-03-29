using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBehavior : MonoBehaviour
{

    public GameObject cardsInHand = new GameObject[60]; // max hand size 60
    public string cardsInDeck = new string[60]; // deck size; stores names of cards

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
        int index = 0;
        for (int i = 1; i < 13; i++)
        {
            cardsInDeck[index] = i + "C";
            cardsInDeck[index + 1] = i + "D";
            cardsInDeck[index + 2] = i + "H";
            cardsInDeck[index + 3] = i + "S";
            index += 4;
        }

        Shuffle(); 
    }

    public void Shuffle() {

        for (int i = 1; i < 60; i++)
        {
            string a = cardsInDeck[index];
        }
    }

}
