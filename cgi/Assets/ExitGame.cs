using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{

    public void Exit() {
        Debug.Log("exiting");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
