using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Lvl1CompletedManager : MonoBehaviour {

    public Text Score;
    public Text TimeTaken;

    
	// Use this for initialization
	void Start () {
        Score.text = PlayerPrefs.GetInt("score").ToString();
        TimeTaken.text = PlayerPrefs.GetString("timetaken");
        PlayerPrefs.SetString("level1", "done");
    }

    void Transition1()
    {
        SceneManager.LoadScene("LevelScreen");
    }

    public void Transition()
    {
        float fadeTime = GameObject.Find("Lvl1CompletedManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
