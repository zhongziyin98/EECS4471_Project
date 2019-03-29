using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : MonoBehaviour
{

    bool detectingCollision = false;
    bool draw = false; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectingCollision) {
            //detect collision with hand

        }
    }

    public void StartCollisionDetection()
    {
        detectingCollision = true; 

    }

    public void EndCollisionDetection()
    {
        detectingCollision = false;
        if (draw) {
            // draw a card
        }

    }



}
