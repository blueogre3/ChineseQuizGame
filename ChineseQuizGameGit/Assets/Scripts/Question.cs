using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Question {

    public string question;
    public string choice1;
    public string choice2;
    public string choice3;
    public string choice4;
    public string pinyin1;
    public string pinyin2;
    public string pinyin3;
    public string pinyin4;
    public int type1;
    public int type2;
    public int type3;
    public int type4;
    public AudioClip audio;
    public MovieTexture movie;
    public string answer;
    public int numTries;

}
