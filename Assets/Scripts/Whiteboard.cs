using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Whiteboard : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    Keyboard keyboard;

    public void Interact()
    {
        if (!keyboard)
            keyboard = FindObjectOfType<Keyboard>();
        keyboard.gameObject.SetActive(true);
        keyboard.Edit(text);

    }

}
