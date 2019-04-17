using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPanelSize : MonoBehaviour
{

    public static Vector3 DEFAULT_SIZE = new Vector3(0.6f, 0.6f, 0.6f);

    public float size = 1.0f; 
    public float targetSize = 1.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        size = size * 0.8f + targetSize * 0.2f; 
        transform.localScale = DEFAULT_SIZE * size; 
    }

    public void SetSize(float val){
        targetSize = val; 

    }


}
