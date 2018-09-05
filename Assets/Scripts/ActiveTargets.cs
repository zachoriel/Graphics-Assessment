using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveTargets : MonoBehaviour
{
    public TextMeshProUGUI activeTargetsText;

    [HideInInspector]
    public GameObject[] activeTargets;

	// Use this for initialization
	void Start ()
    {
        activeTargets = GameObject.FindGameObjectsWithTag("Target");
        activeTargetsText.text = "Active Targets: " + activeTargets.Length.ToString();
        activeTargetsText.color = Color.red;

    }
}
