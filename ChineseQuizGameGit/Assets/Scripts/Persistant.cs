using UnityEngine;
using System.Collections;

public class Persistant : MonoBehaviour {

    public int score;

    void awake()
    {
        DontDestroyOnLoad(this);
    }
}
