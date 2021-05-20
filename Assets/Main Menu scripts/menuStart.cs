using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuStart : MonoBehaviour
{
    public void start()
    {
        if (Camera.main.aspect >= 1.7)
    Debug.Log("16:9");
    else if (Camera.main.aspect >= 1.5)
    Debug.Log("3:2");
    else
    Debug.Log("4:3");
 

    }





    public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }

}

