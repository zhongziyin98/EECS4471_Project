using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanvasOpacity : MonoBehaviour
{
    float targetOpacity = 0.0f; // 0 = transparent, 1 = opaque
    float dOpacity = 4.0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float a = gameObject.GetComponent<CanvasGroup>().alpha;
        float diff = targetOpacity - a; 
        if (Mathf.Abs(diff) <= (dOpacity * Time.deltaTime)) {
            gameObject.GetComponent<CanvasGroup>().alpha = targetOpacity;
        }
        else
        {
            gameObject.GetComponent<CanvasGroup>().alpha += (Mathf.Sign(diff) * dOpacity * Time.deltaTime); 
        }

        
    }

    public void SetTargetOpacity(float op) {
        targetOpacity = op; 

    }

}
