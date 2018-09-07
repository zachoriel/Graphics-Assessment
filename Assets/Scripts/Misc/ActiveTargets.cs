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

	// Use this for initialization
	void Start ()
    {
        activeTargetsText.color = Color.red;
    }

    // Constantly updates # of targets for the UI
    void Update()
    {
        activeTargets = GameObject.FindGameObjectsWithTag("Target");
        activeTargetsText.text = "Active Targets: " + activeTargets.Length.ToString();
    }
}
