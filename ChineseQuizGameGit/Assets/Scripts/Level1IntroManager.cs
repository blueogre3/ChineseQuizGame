using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class Level1IntroManager : MonoBehaviour {

    //[SerializeField]
    //public Instructions[] lvl1instructions;
    //private static List<Instructions> futureInstructions;
    //private Instructions currentInstruction;

    [SerializeField]
    private Text instructionText;

    [SerializeField]
    private int clickcount;

    void Start () {
        /*
        if (futureInstructions == null)
        {
            futureInstructions = lvl1instructions.ToList<Instructions>();
        }
        currentInstruction = futureInstructions[0];
        instructionText.text = currentInstruction.instruction;
        futureInstructions.RemoveAt(0);
        */
        instructionText.text = "You are a sophomore at Fudan University. It is the 2nd week of your World History class with Professor Li.";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Transition1()
    {
        SceneManager.LoadScene("Level1Vid");
    }

    void Transition()
    {
        float fadeTime = GameObject.Find("Level1IntroManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);
    }

    void Menu()
    {
        SceneManager.LoadScene("LevelScreen");
    }

    public void TransitionMenu()
    {
        float fadeTime = GameObject.Find("Level1IntroManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Menu", fadeTime);
    }

    public void setInstruction()
    {
        if (clickcount >= 2)
        {
            Transition();
        }
        
        /*
        currentInstruction = futureInstructions[0];
        instructionText.text = currentInstruction.instruction;
        futureInstructions.RemoveAt(0);
        clickcount++;
        */

        if (clickcount == 0)
        {
            instructionText.text = "You have a severe migraine headache, so you missed a class and a quiz. You are worried that this might affect Professor Li’s impression about you.";
            clickcount++;
        }

        else if (clickcount == 1)
        {
            instructionText.text = "You go to Professor Li’s office to apologize for your absence and explain the reason. You ask if you can have a make-up quiz. Let’s get started!";
            clickcount++;
        }
    }
}
