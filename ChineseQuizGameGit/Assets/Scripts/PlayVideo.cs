using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]


public class PlayVideo: MonoBehaviour {

    public MovieTexture movie;
    private AudioSource audio;


	// Use this for initialization
	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
	}

    void Transition1()
    {
        SceneManager.LoadScene("StarterScene");
    }

    void Transition()
    {
        float fadeTime = GameObject.Find("Level1VidManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);
    }

    // Update is called once per frame
    void Update () {
	    if(!movie.isPlaying)
        {
            Transition();
        }
	}
}
