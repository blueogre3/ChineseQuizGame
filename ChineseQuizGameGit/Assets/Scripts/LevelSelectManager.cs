using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class LevelSelectManager : MonoBehaviour {

    public Text lvl1completed;
    public Text lvl2completed;
    public Text lvl3completed;

	void Start () {
	    if(PlayerPrefs.GetString("level1") != null && PlayerPrefs.GetString("level1") == "done")
        {
            lvl1completed.text = "Completed!";
        }

        if (PlayerPrefs.GetString("level2") != null && PlayerPrefs.GetString("level2") == "done")
        {
            lvl2completed.text = "Completed!";
        }
    }

    void Transition1()
    {
        SceneManager.LoadScene("Level1Intro");
    }

    void Transition2()
    {
        SceneManager.LoadScene("Level2Intro");
    }

    public void Transition()
    {
        float fadeTime = GameObject.Find("LevelSelectManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);

    }
    public void Trans2()
    {
        float fadeTime = GameObject.Find("LevelSelectManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition2", fadeTime);

    }
}
