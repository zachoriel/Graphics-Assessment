using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Components & scripts
    [Header("Component Setup")]
    public Animator animator;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Text timerText;
    DialogueTrigger trigger;
    SoundManager typingSounds;
    Queue<string> sentences;

    // Audio files & sound delay
    [Header("Typing Sounds")]
    public AudioClip letterSound1;
    public AudioClip letterSound2;
    public AudioClip letterSound3;
    public AudioClip letterSound4;
    public AudioClip letterSound5;
    public AudioClip letterSound6;
    public float letterPause = 0.1f;

    // Variable for the crash timer event
    [Header("Crash Variables")]
    public float crashTimer = 10f;


	// Use this for initialization
	void Start ()
    {
        trigger = FindObjectOfType<DialogueTrigger>();
        typingSounds = FindObjectOfType<SoundManager>();
        sentences = new Queue<string>();

        timerText.enabled = false;
        timerText.text = "Crash Timer: " + crashTimer.ToString();
    }

    // If player engages with Bob before destroying any asteroids
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        if (typingSounds.gameObject.activeInHierarchy == false)
        {
            typingSounds.gameObject.SetActive(true);
        }

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // Dialogue advances to the next text
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        // Stops the current text typing animation if the player advances to the next text before the animation is finished
        StopAllCoroutines();

        // Starts the next text typing animation
        StartCoroutine(TypeSentence(sentence));
    }

    // Coroutine for the text typing animation & audio
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            if (letterSound1 && letterSound2 && letterSound3 && letterSound4 && letterSound5 && letterSound6)
            {
                SoundManager.instance.RandomizeSfx(letterSound1, letterSound2, letterSound3, letterSound4, letterSound5, letterSound6);
            }

            yield return new WaitForSeconds(letterPause);
        }
    }

    // If the player reaches the end of the conversation with Bob, or leaves the trigger area
    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);

        typingSounds.gameObject.SetActive(false);

        StopAllCoroutines();
    }

    // If the player engages with Bob after destroying any asteroids
    public void Dismiss(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        if (typingSounds.gameObject.activeInHierarchy == false)
        {
            typingSounds.gameObject.SetActive(true);
        }

        nameText.text = dialogue.name;

        sentences.Clear();

        dialogueText.text = "Oh, NOW you wanna talk to me, eh? Well guess what bub, tough shit! You clearly already know what to do since you've already started, " +
            "and I'm not gonna waste my time. Get outta my sight, scrub!";

        trigger.timesTalkedToBob = 9; // So that the next interaction will be Bob ignoring you
    }

    // If the player has finished the coversation with Bob and continues attempting to engage with him
    public void Ignore(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        if (typingSounds.gameObject.activeInHierarchy == false)
        {
            typingSounds.gameObject.SetActive(true);
        }

        nameText.text = dialogue.name;

        sentences.Clear();

        if (trigger.timesTalkedToBob == 10)
        {
            dialogueText.text = "Are you dense, m8? I'm done talking to you, jabroni. SCRAM!";
        }
        else if (trigger.timesTalkedToBob >= 11 && trigger.timesTalkedToBob < 15)
        {
            dialogueText.text = "*Bob pretends not to notice you*";
        }
        else if (trigger.timesTalkedToBob >= 15 && trigger.timesTalkedToBob < 20)
        {
            dialogueText.text = "Error 404: Message Not Found";
        }
        else if (trigger.timesTalkedToBob == 20)
        {
            Application.ForceCrash(0); // ;)
        }
    }

    void Update()
    {
        // Player progresses the conversation
        if (trigger.talkingToBob && Input.GetKeyDown(KeyCode.RightArrow))
        {
            DisplayNextSentence();
            trigger.timesTalkedToBob++;
        }

        // Triggers end of conversation & crash timer event
        if (trigger.timesTalkedToBob == 8)
        {
            StartCoroutine(CrashTimer());
        }

        // Stops crash timer event. Occurs when player progresses conversation OR exits trigger area
        if (trigger.timesTalkedToBob == 9)
        {
            crashTimer = 1000000f;
            timerText.gameObject.SetActive(false);
        }

        // Conclusion of crash timer event. Crashes the program
        if (crashTimer <= 0)
        {
            Application.ForceCrash(0); // ;)
        }

        timerText.text = "Crash Timer: " + Mathf.RoundToInt(crashTimer).ToString();
    }

    // Used a coroutine so I could wait to start the crash timer until the text finished animating. Number of seconds = time it takes for text to animate 
    // Adjust accordingly
    IEnumerator CrashTimer()
    {
        yield return new WaitForSeconds(17);
        StartCrashTimer();
        yield break;
    }

    // Actual starting of the crash timer
    void StartCrashTimer()
    {
        StopCoroutine(CrashTimer());

        timerText.enabled = true;
        crashTimer -= 1 * Time.deltaTime;
        crashTimer = Mathf.Clamp(crashTimer, 0, 1000000);
    }
}
