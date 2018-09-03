using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BobTrigger : MonoBehaviour  
{
    public Canvas bobsCanvas;

    [Header("Scripts")]
    public TextTyper1 typer1;
    public TextTyper2 typer2;
    public TextTyper3 typer3;
    public TextTyper4 typer4;
    public TextTyper5 typer5;
    public TextTyper6 typer6;
    public TextTyper7 typer7;
    public TextTyper8 typer8;
    public TextTyper9 typer9;

    [Header("Texts")]
    public TextMeshProUGUI intro1;
    public TextMeshProUGUI intro2;
    public TextMeshProUGUI instructions1;
    public TextMeshProUGUI instructions2;
    public TextMeshProUGUI instructions3;
    public TextMeshProUGUI anger1;
    public TextMeshProUGUI anger2;
    public TextMeshProUGUI anger3;
    public TextMeshProUGUI diss;
    public TextMeshProUGUI pressToContinue;

    string playerTag = "MainCamera";
    bool hasTalkedToBob, pesteringBob;
    int pesterCount = 0;

    BobConvoManager convo;

	// Use this for initialization
	void Start ()
    {
        typer1 = FindObjectOfType<TextTyper1>();
        typer2 = FindObjectOfType<TextTyper2>();
        typer3 = FindObjectOfType<TextTyper3>();
        typer4 = FindObjectOfType<TextTyper4>();
        typer5 = FindObjectOfType<TextTyper5>();
        typer6 = FindObjectOfType<TextTyper6>();
        typer7 = FindObjectOfType<TextTyper7>();
        typer8 = FindObjectOfType<TextTyper8>();
        typer9 = FindObjectOfType<TextTyper9>();

        convo = FindObjectOfType<BobConvoManager>();

        bobsCanvas.enabled = false;

        typer1.enabled = false;
        intro1.enabled = false;

        hasTalkedToBob = false;
        pesteringBob = false;
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == playerTag && hasTalkedToBob == false)
        {
             

            bobsCanvas.enabled = true;

            intro1.enabled = true;
            typer1.enabled = true;

            hasTalkedToBob = true;
        }
        else if (other.gameObject.tag == playerTag && hasTalkedToBob && pesteringBob == false)
        {
            bobsCanvas.enabled = true;

            diss.enabled = true;
            typer9.enabled = true;

            pesteringBob = true;
        }
        else if (other.gameObject.tag == playerTag && pesteringBob)
        {
            bobsCanvas.enabled = true;

            diss.enabled = true;

            if (pesterCount < 10)
            {
                diss.text = "*Bob pretends not to notice you*";
            }
            else if (pesterCount >= 10 && pesterCount < 20)
            {
                diss.text = "404: Message Not Found.";
            }
            else
            {
                Application.ForceCrash(1); // ;)
            }

            typer9.enabled = true;

            pesterCount++;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == playerTag)
        {
            bobsCanvas.enabled = false;

            typer1.enabled = false;
            typer2.enabled = false;
            typer3.enabled = false;
            typer4.enabled = false;
            typer5.enabled = false;
            typer6.enabled = false;
            typer7.enabled = false;
            typer8.enabled = false;
            typer9.enabled = false;

            intro1.enabled = false;
            intro2.enabled = false;
            instructions1.enabled = false;
            instructions2.enabled = false;
            instructions3.enabled = false;
            anger1.enabled = false;
            anger2.enabled = false;
            anger3.enabled = false;
            diss.enabled = false;

            if (convo.crashTimer < 10 )
            {
                convo.crashTimer = 1000000f;
                convo.timerText.gameObject.SetActive(false);
            }
        }
    }
}
