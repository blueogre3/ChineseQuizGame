using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class GameInstructions2Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Transition1()
    {
        SceneManager.LoadScene("LevelScreen");
    }

    public void Transition()
    {
        float fadeTime = GameObject.Find("GameInstructions2Manager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);

    }
}
