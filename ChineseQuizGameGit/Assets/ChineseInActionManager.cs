using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChineseInActionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Transition1()
    {
        SceneManager.LoadScene("ZackIntro");
    }

    public void Transition()
    {
        float fadeTime = GameObject.Find("ChineseInActionManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);

    }

    void Back()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void TransitionBack()
    {
        float fadeTime = GameObject.Find("ChineseInActionManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Back", fadeTime);
    }
}
