using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Lvl2CompletedManager : MonoBehaviour
{

    public Text Score;
    public Text TimeTaken;


    // Use this for initialization
    void Start()
    {
        Score.text = PlayerPrefs.GetInt("score2").ToString();
        TimeTaken.text = PlayerPrefs.GetString("timetaken2");
        PlayerPrefs.SetString("level2", "done");
    }

    void Transition1()
    {
        SceneManager.LoadScene("LevelScreen");
    }

    public void Transition()
    {
        float fadeTime = GameObject.Find("Lvl2CompletedManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
