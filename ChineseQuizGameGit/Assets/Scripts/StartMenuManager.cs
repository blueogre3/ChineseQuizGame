using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class StartMenuManager : MonoBehaviour {
    
    void Start()
    {
        
    }

    void Transition1 ()
    {
        SceneManager.LoadScene("ChineseInAction");
    }

    public void Transition()
    {
        float fadeTime = GameObject.Find("StartMenuManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);
        
    }
}
