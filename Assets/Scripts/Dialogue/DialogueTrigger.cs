using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    // Components & scripts
    [Header("Component Setup")]
    public Dialogue dialogue;
    public Canvas bobCanvas;
    ActiveTargets targets;

    // Used to make sure conversation can't be progressed if the player is not currently engaged with Bob
    [HideInInspector]
    public bool talkingToBob;

    // Used to determine Bob's dialogue during and after conversation
    [HideInInspector]
    public int timesTalkedToBob;

    // Tag management. Used for collision detection w/ Bob
    string playerTag = "Player";

    void Start()
    {
        targets = FindObjectOfType<ActiveTargets>();
        timesTalkedToBob = 0;
    }

    // If player engages with Bob by entering the trigger area
    void OnTriggerEnter(Collider other)
    {
        timesTalkedToBob++;

        // If player engages with Bob without destroying any asteroids first
        if (other.gameObject.tag == playerTag && timesTalkedToBob < 10 && targets.activeTargets.Length == 100)
        {
            ToggleConvo();
            TriggerDialogue();
        }

        // If player engages with Bob after destroying any asteroids
        if (other.gameObject.tag == playerTag && timesTalkedToBob < 10 && targets.activeTargets.Length < 100)
        {
            ToggleConvo();
            TriggerDismissiveAttitude();
        }

        // If player engages with Bob too many times
        if (other.gameObject.tag == playerTag && timesTalkedToBob >= 10)
        {
            ToggleConvo();
            TriggerIgnoring();
        }
    }

    // If player ceases engaging with Bob by exiting the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            ToggleConvo();
            ExitDialogue();
        }
    }

    // Method to toggle the 'talkingToBob' boolean. Ensures conversation can't be progressed if player isn't engaged with Bob
    void ToggleConvo()
    {
        if (talkingToBob == false)
        {
            talkingToBob = true;
        }
        else
        {
            talkingToBob = false;
        }
    }

    // If player engages with Bob before destroying any asteroids
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    // If the player reaches the end of the conversation with Bob, or leaves the trigger area
    public void ExitDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }

    // If the player engages with Bob after destroying any asteroids
    public void TriggerDismissiveAttitude()
    {
        FindObjectOfType<DialogueManager>().Dismiss(dialogue);
    }

    // If the player has finished the coversation with Bob and continues attempting to engage with him
    public void TriggerIgnoring()
    {
        FindObjectOfType<DialogueManager>().Ignore(dialogue);
    }
}
