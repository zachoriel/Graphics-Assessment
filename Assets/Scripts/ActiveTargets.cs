using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveTargets : MonoBehaviour
{
    public TextMeshProUGUI activeTargetsText;
    GameObject[] activeTargets;

	// Use this for initialization
	void Start ()
    {
        activeTargets = GameObject.FindGameObjectsWithTag("Target");
	}
	
	// Update is called once per frame
	void Update ()
    {
        activeTargets = GameObject.FindGameObjectsWithTag("Target");
        activeTargetsText.text = "Active Targets: " + activeTargets.Length.ToString();  // This is so inefficient but frankly I don't really care right now. Down the road I'll have it check when an object is destroyed.

        if (activeTargets.Length > 66)
        {
            activeTargetsText.color = Color.red;
        }
        else if (activeTargets.Length > 33 && activeTargets.Length <= 66)
        {
            activeTargetsText.color = Color.yellow;
        }
        else if (activeTargets.Length < 33)
        {
            activeTargetsText.color = Color.green;
        }
    }
}
