using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayVideoRight : MonoBehaviour {

    public MovieTexture movie;

    // Use this for initialization
    void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        movie.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (!movie.isPlaying)
        {
            SceneManager.LoadScene("StarterScene");
        }
    }
}
