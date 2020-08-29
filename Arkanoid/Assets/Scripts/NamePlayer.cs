using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlayer : MonoBehaviour
{
    private void Start()
    {
        var input = gameObject.GetComponent<InputField>();

        input.onValidateInput += delegate (string s, int i, char c) { return char.ToUpper(c); };

        var eventInput = new InputField.SubmitEvent();
        eventInput.AddListener(SubmitName);

        input.onEndEdit = eventInput;
    }

    private void SubmitName(string name)
    {
        PlayerPrefs.SetString("Name", name);
        PlayerPrefs.SetString("Points", "0");
    }
}
