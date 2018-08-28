using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextTyper6 : MonoBehaviour
{   
    public float letterPause = 0.2f;
    public AudioClip letterSound1, letterSound2, letterSound3, letterSound4, letterSound5, letterSound6;

    string message;
    public TextMeshProUGUI bobAnger1;

    // Use this for initialization
    void Start()
    {
        message = bobAnger1.text;
        bobAnger1.text = "";

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            bobAnger1.text += letter;

            if (letterSound1 && letterSound2 && letterSound3 && letterSound4 && letterSound5 && letterSound6)
            {
                SoundManager.instance.RandomizeSfx(letterSound1, letterSound2, letterSound3, letterSound4, letterSound5, letterSound6);
            }

            yield return 0;

            yield return new WaitForSeconds(letterPause);
        }
    }
}