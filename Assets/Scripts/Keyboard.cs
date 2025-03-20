using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keyboard : MonoBehaviour
{
    TMP_Text text;

    public void Append(string c) { 
        text.text = text.text + c;
    }

    public void Cancel()
    {
        if (text.text.Length > 0)
        {
            text.text=text.text.Substring(0, text.text.Length - 1);
        }
    }

    public void Edit(TMP_Text t)
    {
        text = t;
    }

    public void Enter()
    {
        gameObject.SetActive(false);
    }
}
