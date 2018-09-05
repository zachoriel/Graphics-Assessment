﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextTyper5 : MonoBehaviour
{   
    public float letterPause = 0.2f;
    public AudioClip letterSound1, letterSound2, letterSound3, letterSound4, letterSound5, letterSound6;

    string message;
    public TextMeshProUGUI bobInstructions3;

    // Use this for initialization
    void Start()
    {
        message = bobInstructions3.text;
        bobInstructions3.text = "";

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            bobInstructions3.text += letter;

            if (letterSound1 && letterSound2 && letterSound3 && letterSound4 && letterSound5 && letterSound6)
            {
                SoundManager.instance.RandomizeSfx(letterSound1, letterSound2, letterSound3, letterSound4, letterSound5, letterSound6);
            }

            yield return 0;

            yield return new WaitForSeconds(letterPause);
        }
    }
}