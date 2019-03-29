using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTexture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		SetTexture("1S"); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetTexture(string name){
		var ren = gameObject.GetComponent<Renderer>();
		Texture t = Resources.Load("cardface/" + name) as Texture; 
		ren.material.mainTexture = t;
        Debug.Log("cardface/" + name);
	}
}
