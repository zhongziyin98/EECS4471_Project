using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPanelSize : MonoBehaviour
{

    public static Vector3 DEFAULT_SIZE = new Vector3(0.6f, 0.6f, 0.6f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(float val){
        transform.localScale = DEFAULT_SIZE * val; 

    }


}
