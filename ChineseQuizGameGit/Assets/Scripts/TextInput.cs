using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{

    InputField input;
    InputField.SubmitEvent se;
    public Text output;

    void Start()
    {
        input = gameObject.GetComponent<InputField>();
        se = new InputField.SubmitEvent();
        se.AddListener(SubmitInput);
        input.onEndEdit = se;

    }

    private void SubmitInput(string arg0)
    {
        Debug.Log(arg0);
    }


}
