using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DrawCard : MonoBehaviour
{
    // private bool isCollidedWithObj1 = false;
    // private bool isCollidedWithObj2 = false;
    bool draw = false;

    public DeckBehavior db; 

    /*public void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.name == "RigidRoundHand_R")
            Debug.Log("touch");
        isCollidedWithObj1 = true;
       // else if (collision.gameObject.name == "Deck")
         //   isCollidedWithObj2 = true;
        if (isCollidedWithObj1)
            Debug.Log("touch");
        draw = true;
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "RigidRoundHand_R")
        {
            isCollidedWithObj1 = false;
            draw = false;
        }
    }
    public void SwipeinStart()
    {
       
        if (draw == true)
        {
            Debug.Log("draw");
            isCollidedWithObj1 = false;
            draw = false;
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CubeTip")
            draw = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CubeTip") //LoPoly Rigged Hand Right
            draw = false;
    }
    public void SwipeinStart()
    {

        if (draw == true)
        {
            Debug.Log("draw");

            db.DrawCard();

            draw = false;
        }
    }
}