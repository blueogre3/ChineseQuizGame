using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HelpZackManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Transition1()
    {
        SceneManager.LoadScene("GameInstructions");
    }

    public void Transition()
    {
        float fadeTime = GameObject.Find("HelpZackManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);
    }

    void Back()
    {
        SceneManager.LoadScene("ZackAbroad");
    }

    public void TransitionBack()
    {
        float fadeTime = GameObject.Find("HelpZackManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Back", fadeTime);
    }
}
