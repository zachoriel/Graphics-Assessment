using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BobConvoManager : MonoBehaviour // I am so sorry for this
{
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
    public Text timerText;

    //[HideInInspector]
    public float crashTimer = 10f;

    // Use this for initialization
    void Start () 
    {
        typer1 = GetComponent<TextTyper1>();
        typer2 = GetComponent<TextTyper2>();
        typer3 = GetComponent<TextTyper3>();
        typer4 = GetComponent<TextTyper4>();
        typer5 = GetComponent<TextTyper5>();
        typer6 = GetComponent<TextTyper6>();
        typer7 = GetComponent<TextTyper7>();
        typer8 = GetComponent<TextTyper8>();
        typer9 = GetComponent<TextTyper9>();

        timerText.enabled = false;
        timerText.text = "Crash Timer: " + crashTimer.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (intro1.enabled && Input.GetKeyDown(KeyCode.RightArrow))
        {
            intro1.enabled = false;
            typer1.enabled = false;

            intro2.enabled = true;
            typer2.enabled = true;
        }

        else if (intro2.enabled && Input.GetKeyDown(KeyCode.RightArrow))
        {
            intro2.enabled = false;
            typer2.enabled = false;

            instructions1.enabled = true;
            typer3.enabled = true;
        }

        else if (instructions1.enabled && Input.GetKeyDown(KeyCode.RightArrow))
        {
            instructions1.enabled = false;
            typer3.enabled = false;

            instructions2.enabled = true;
            typer4.enabled = true;
        }

        else if (instructions2.enabled && Input.GetKeyDown(KeyCode.RightArrow))
        {
            instructions2.enabled = false;
            typer4.enabled = false;

            instructions3.enabled = true;
            typer5.enabled = true;
        }

        else if (instructions3.enabled && Input.GetKeyDown(KeyCode.RightArrow))
        {
            instructions3.enabled = false;
            typer5.enabled = false;

            anger1.enabled = true;
            typer6.enabled = true;
        }

        else if (anger1.enabled && Input.GetKeyDown(KeyCode.RightArrow))
        {
            anger1.enabled = false;
            typer6.enabled = false;

            anger2.enabled = true;
            typer7.enabled = true;
        }

        else if (anger2.enabled && Input.GetKeyDown(KeyCode.RightArrow))
        {
            anger2.enabled = false;
            typer7.enabled = false;

            anger3.enabled = true;
            typer8.enabled = true;
        }

        else if (anger3.enabled)
        {
            pressToContinue.enabled = false;
            StartCoroutine(CrashTimer());
        }

        else if (diss.enabled)
        {
            pressToContinue.enabled = false;
        }

        timerText.text = "Crash Timer: " + Mathf.RoundToInt(crashTimer).ToString();

        if (crashTimer <= 0)
        {
            Application.ForceCrash(1); // ;)
        }
    }

    IEnumerator CrashTimer()
    {
        yield return new WaitForSeconds(17);
        StartCrashTimer();
        yield break;
    }

    void StartCrashTimer()
    {
        StopCoroutine(CrashTimer());

        timerText.enabled = true;
        crashTimer -= 1 * Time.deltaTime;
        crashTimer = Mathf.Clamp(crashTimer, 0, 1000000);
    }
}
