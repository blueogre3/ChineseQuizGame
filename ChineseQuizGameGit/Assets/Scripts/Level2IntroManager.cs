using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class Level2IntroManager : MonoBehaviour
{

    //[SerializeField]
    //public Instructions[] lvl1instructions;
    //private static List<Instructions> futureInstructions;
    //private Instructions currentInstruction;

    [SerializeField]
    private Text instructionText;

    [SerializeField]
    private int clickcount;

    void Start()
    {
        /*
        if (futureInstructions == null)
        {
            futureInstructions = lvl1instructions.ToList<Instructions>();
        }
        currentInstruction = futureInstructions[0];
        instructionText.text = currentInstruction.instruction;
        futureInstructions.RemoveAt(0);
        */
        instructionText.text = "You are meeting with your Chinese friend, Xiaofei, for lunch to catch up. You haven’t seen her for a few weeks.";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Transition1()
    {
        SceneManager.LoadScene("StarterScene2");
    }

    void Transition()
    {
        float fadeTime = GameObject.Find("Level2IntroManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);
    }

    void Menu()
    {
        SceneManager.LoadScene("LevelScreen");
    }

    public void TransitionMenu()
    {
        float fadeTime = GameObject.Find("Level2IntroManager").GetComponent<Fading>().BeginFade(1);
        Invoke("Menu", fadeTime);
    }

    public void setInstruction()
    {
        if (clickcount >= 2)
        {
            Transition();
        }
        
        if (clickcount == 0)
        {
            instructionText.text = "You have arrived 10 minutes late for the lunch.";
            clickcount++;
        }

        else if (clickcount == 1)
        {
            instructionText.text = "You apologize for being late and start the conversation with small talk. Let’s get started!";
            clickcount++;
        }
    }
}
