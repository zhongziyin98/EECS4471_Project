using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBehavior : MonoBehaviour
{
    public CardTexture card;


    public ArrayList cardsInHand = new ArrayList(); // max hand size 60
    public List<string> cardsInDeck = new List<string>(); // deck size; stores names of cards

    // Start is called before the first frame update
    void Start()
    {
        InitiateDeck();

        DrawCard();
    }

    // Update is called once per frame
    void Update()
    {
        //RenderCardPosition();
    }


    public void DrawCard()
    {
        CardTexture go = Instantiate(card, new Vector3(1, 2, 0), Quaternion.identity);
        //string s = cardsInDeck.RemoveAt(cardsInDeck.Count - 1);
        go.SetTexture("1D");
        cardsInHand.Add(go);
    }

    public void RenderCardPosition()
    {
        int n = cardsInHand.Count;

        for (int i = 0; i < n; i++)
        {
           // GameObject go = (GameObject) cardsInHand[i];

        }
    }

    public void InitiateDeck()
    {

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

}
