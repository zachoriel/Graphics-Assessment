using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveTargets : MonoBehaviour
{
    // UI stuff
    [Header("Targets UI Element")]
    public TextMeshProUGUI activeTargetsText;

    // Active targets array. Used for controlling Bob's interactions with you, and the win condition
    [HideInInspector]
    public GameObject[] activeTargets;
    [HideInInspector]
    public int startingTargets;

    private double twoThirdsOfTargets, oneThirdOfTargets;

	// Use this for initialization
	void Start ()
    {
        activeTargets = GameObject.FindGameObjectsWithTag("Target");
        startingTargets = activeTargets.Length;
        twoThirdsOfTargets = startingTargets * 0.66;
        oneThirdOfTargets = startingTargets * 0.33;
        activeTargetsText.color = Color.red;
    }

    // Constantly updates # of targets for the UI
    void Update()
    {
        activeTargets = GameObject.FindGameObjectsWithTag("Target");
        activeTargetsText.text = "Active Targets: " + activeTargets.Length.ToString();

        // If the player has destroyed less than 33% of the asteroids, UI is red
        if (activeTargets.Length > twoThirdsOfTargets)
        {
            activeTargetsText.color = Color.red;
        }
        // If the player has destroyed between 33% and 66% of the asteroids, UI is yellow
        else if (activeTargets.Length > oneThirdOfTargets && activeTargets.Length <= twoThirdsOfTargets)
        {
            activeTargetsText.color = Color.yellow;
        }
        // If the player has destroyed greater than 66% of the asteroids, UI is green
        else if (activeTargets.Length <= oneThirdOfTargets)
        {
            activeTargetsText.color = Color.green;
        }
    }
}
