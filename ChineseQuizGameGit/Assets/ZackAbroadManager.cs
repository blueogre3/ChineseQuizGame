using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ZackAbroadManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Transition1()
    {
        SceneManager.LoadScene("ZackHelp");
    }

    public void Transition()
    {
        float fadeTime = GameObject.Find("ZackAbroadManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);
    }

    void Back()
    {
        SceneManager.LoadScene("ZackIntro");
    }

    public void TransitionBack()
    {
        float fadeTime = GameObject.Find("ZackAbroadManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Back", fadeTime);
    }
}
