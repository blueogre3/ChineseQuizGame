using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(AudioSource))]

public class GameManager2 : MonoBehaviour
{

    //data storing script
    private int correctNumber;
    //public Persistant Script;

    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;

    private float time = 0;
    private bool isPaused;

    [SerializeField]
    public string timerLabel;

    [SerializeField]
    public Texture smile;

    [SerializeField]
    public Texture frown;

    [SerializeField]
    private float timeBetweenQuestions = 0f;

    [SerializeField]
    private Text QuestionText;

    [SerializeField]
    private Text Score;

    [SerializeField]
    private RawImage Movie;

    [SerializeField]
    private int ScoreNum;

    [SerializeField]
    private Text Answer1;

    [SerializeField]
    private Text Answer2;

    [SerializeField]
    private Text Answer3;

    [SerializeField]
    private Text Answer4;

    [SerializeField]
    private Text pinyin1;

    [SerializeField]
    private Text pinyin2;

    [SerializeField]
    private Text pinyin3;

    [SerializeField]
    private Text pinyin4;

    [SerializeField]
    private AudioSource currentAudio;

    [SerializeField]
    private RawImage currentMovie;

    [SerializeField]
    private Text playerSelection;

    void Start()
    {
        isPaused = false;
        correctNumber = 0;
        answerDisappear();
        GameObject.Find("RawImage").transform.localScale = new Vector3(0, 0, 0);
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        SetCurrentQuestion();
    }

    void Update()
    {
        time += Time.deltaTime;
        var minutes = time / 60;
        var seconds = time % 60;
        timerLabel = string.Format("{0:00} : {1:00}", Math.Floor(minutes), Math.Floor(seconds));
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        Time.timeScale = isPaused ? 0 : 1;
        if (isPaused == false)
        {
            GameObject.Find("Pause").transform.localScale = new Vector3(0, 0, 0);
        }
        if (isPaused == true)
        {
            GameObject.Find("Pause").transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Transition1()
    {
        SceneManager.LoadScene("Lvl2Completed");
    }

    void Transition()
    {
        float fadeTime = GameObject.Find("GameManager2").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition1", fadeTime);
    }

    void Last()
    {
        shrink();
        answerDisappear();
        SetCurrentQuestion();
        Invoke("Transition", 2f);
    }

    void Transition2()
    {
        SceneManager.LoadScene("LevelScreen");
    }

    public void TransitionLevel()
    {
        float fadeTime = GameObject.Find("GameManager2").GetComponent<Fading>().BeginFade(1);
        Invoke("Transition2", fadeTime);
    }

    void shrink()
    {
        GameObject.Find("RawImage").transform.localScale = new Vector3(0, 0, 0);
    }

    void answerDisappear()
    {
        GameObject.Find("Panel1").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Panel2").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Panel3").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Panel4").transform.localScale = new Vector3(0, 0, 0);
    }

    void answerAppear()
    {
        GameObject.Find("Panel1").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Panel2").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Panel3").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Panel4").transform.localScale = new Vector3(1, 1, 1);
    }

    void SetCurrentQuestion()
    {
        playerSelection.text = "";
        currentQuestion = unansweredQuestions[0];
        currentAudio.clip = currentQuestion.audio;
        currentMovie.texture = currentQuestion.movie as MovieTexture;
        if (currentQuestion.numTries == 0 && !currentAudio.isPlaying)
        {
            currentAudio.Play();
            currentQuestion.movie.Play();
        }
        QuestionText.text = currentQuestion.question;
        Score.text = ScoreNum.ToString();
        Answer1.text = currentQuestion.choice1;
        Answer2.text = currentQuestion.choice2;
        Answer3.text = currentQuestion.choice3;
        Answer4.text = currentQuestion.choice4;
        pinyin1.text = currentQuestion.pinyin1;
        pinyin2.text = currentQuestion.pinyin2;
        pinyin3.text = currentQuestion.pinyin3;
        pinyin4.text = currentQuestion.pinyin4;
        Invoke("answerAppear", 3f);
    }

    private void resetQuestion()
    {
        if (correctNumber >= 2)
        {
            Last();
        }
        GameObject inputFieldGo = GameObject.Find("ChineseInput");
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        inputFieldCo.text = "";
        SetCurrentQuestion();
    }

    private void TransitionRight()
    {
        correctNumber++;
        ScoreNum += 40 - (currentQuestion.numTries * 10);
        PlayerPrefs.SetInt("score2", ScoreNum);
        PlayerPrefs.SetString("timetaken2", timerLabel);
        unansweredQuestions.RemoveAt(0);
        answerDisappear();
        Invoke("resetQuestion", timeBetweenQuestions);
    }

    private void TransitionWrong()
    {
        Invoke("resetQuestion", timeBetweenQuestions);
    }

    public void Submit()
    {
        GameObject inputFieldGo = GameObject.Find("ChineseInput");
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        if (inputFieldCo.text.CompareTo(currentQuestion.choice1) == 0)
        {
            if (currentQuestion.type1 == 1)
            {
                Movie.texture = smile;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 4f);
                QuestionText.text = "<size=24><color=purple>Correct!</color></size>";
                Invoke("TransitionRight", 0f);
            }
            else if (currentQuestion.type1 == 2)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The expression is not appropriate for this situation. Think about the situation (setting, characters’ roles, topic, communicative function) and try again.";
                playerSelection.text = "You selected " + currentQuestion.choice1;
                Invoke("TransitionWrong", 6f);
            }
            else if (currentQuestion.type1 == 3)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The form and structure of the expression is not perfectly accurate, so I don’t understand what you are saying. Try again.";
                playerSelection.text = "You selected " + currentQuestion.choice1;
                Invoke("TransitionWrong", 6f);
            }
            else if (currentQuestion.type1 == 4)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The sentence you typed doesn’t respond to what I said. Try again.";
                playerSelection.text = "You selected " + currentQuestion.choice1;
                Invoke("TransitionWrong", 6f);
            }
        }
        else if (inputFieldCo.text.CompareTo(currentQuestion.choice2) == 0)
        {
            if (currentQuestion.type2 == 1)
            {
                Movie.texture = smile;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 4f);
                QuestionText.text = "<size=24><color=purple>Correct!</color></size>";
                Invoke("TransitionRight", 0f);
            }
            else if (currentQuestion.type2 == 2)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The expression is not appropriate for this situation. Think about the situation (setting, characters’ roles, topic, communicative function) and try again.";
                playerSelection.text = "You selected " + currentQuestion.choice2;
                Invoke("TransitionWrong", 6f);
            }
            else if (currentQuestion.type2 == 3)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The form and structure of the expression is not perfectly accurate, so I don’t understand what you are saying. Try again.";
                playerSelection.text = "You selected " + currentQuestion.choice2;
                Invoke("TransitionWrong", 6f);
            }
            else if (currentQuestion.type2 == 4)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The sentence you typed doesn’t respond to what I said. Try again.";
                playerSelection.text = "You selected " + currentQuestion.choice2;
                Invoke("TransitionWrong", 6f);
            }
        }
        else if (inputFieldCo.text.CompareTo(currentQuestion.choice3) == 0)
        {
            if (currentQuestion.type3 == 1)
            {
                Movie.texture = smile;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 4f);
                QuestionText.text = "<size=24><color=purple>Correct!</color></size>";
                Invoke("TransitionRight", 0f);
            }
            else if (currentQuestion.type3 == 2)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The expression is not appropriate for this situation. Think about the situation (setting, characters’ roles, topic, communicative function) and try again.";
                playerSelection.text = "You selected " + currentQuestion.choice3;
                Invoke("TransitionWrong", 6f);
            }
            else if (currentQuestion.type3 == 3)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The form and structure of the expression is not perfectly accurate, so I don’t understand what you are saying. Try again.";
                playerSelection.text = "You selected " + currentQuestion.choice3;
                Invoke("TransitionWrong", 6f);
            }
            else if (currentQuestion.type3 == 4)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The sentence you typed doesn’t respond to what I said. Try again.";
                playerSelection.text = "You selected " + currentQuestion.choice3;
                Invoke("TransitionWrong", 6f);
            }
        }
        else if (inputFieldCo.text.CompareTo(currentQuestion.choice4) == 0)
        {
            if (currentQuestion.type4 == 1)
            {
                Movie.texture = smile;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 4f);
                QuestionText.text = "<size=24><color=purple>Correct!</color></size>";
                Invoke("TransitionRight", 0f);
            }
            else if (currentQuestion.type4 == 2)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The expression is not appropriate for this situation. Think about the situation (setting, characters’ roles, topic, communicative function) and try again.";
                playerSelection.text = "You selected " + currentQuestion.choice4;
                Invoke("TransitionWrong", 6f);
            }
            else if (currentQuestion.type4 == 3)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The form and structure of the expression is not perfectly accurate, so I don’t understand what you are saying. Try again.";
                playerSelection.text = "You selected " + currentQuestion.choice4;
                Invoke("TransitionWrong", 6f);
            }
            else if (currentQuestion.type4 == 4)
            {
                if (currentQuestion.numTries < 4)
                {
                    currentQuestion.numTries++;
                }
                Movie.texture = frown;
                GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
                Invoke("shrink", 10f);
                QuestionText.text = "The sentence you typed doesn’t respond to what I said. Try again.";
                playerSelection.text = "You selected " + currentQuestion.choice4;
                Invoke("TransitionWrong", 6f);
            }
        }
        else
        {
            if (currentQuestion.numTries < 4)
            {
                currentQuestion.numTries++;
            }
            Movie.texture = frown;
            GameObject.Find("RawImage").transform.localScale = new Vector3(1, 1, 1);
            Invoke("shrink", 10f);
            QuestionText.text = "There is a typo in the sentence. Try again.";
            Invoke("TransitionWrong", 6f);
        }
    }



}
