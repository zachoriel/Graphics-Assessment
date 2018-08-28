using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextTyper1 : MonoBehaviour
{   
    public float letterPause = 0.2f;
    public AudioClip letterSound1, letterSound2, letterSound3, letterSound4, letterSound5, letterSound6;

    string message;
    public TextMeshProUGUI bobIntro;

    // Use this for initialization
    void Start()
    {
        message = bobIntro.text;
        bobIntro.text = "";

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            bobIntro.text += letter;

            if (letterSound1 && letterSound2 && letterSound3 && letterSound4 && letterSound5 && letterSound6)
            {
                SoundManager.instance.RandomizeSfx(letterSound1, letterSound2, letterSound3, letterSound4, letterSound5, letterSound6);
            }

            yield return 0;

            yield return new WaitForSeconds(letterPause);
        }
    }
}