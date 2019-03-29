
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
    private bool isCollidedWithObj1 = false;
    private bool isCollidedWithObj2 = false;
    bool draw = false;
    
   
    
    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Hands")
            isCollidedWithObj1 = true;
       // else if (collision.gameObject.name == "Deck")
         //   isCollidedWithObj2 = true;
        if (isCollidedWithObj1)
            Debug.Log("touch");
        draw = true;
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "LoPoly Rigged Hand Right")
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
    }
}
