using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DancingDude : MonoBehaviour
{
    public Canvas speechBubble;
    public Transform mainCamera;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        speechBubble.enabled = false;
	}

    void OnMouseOver()
    {
        speechBubble.enabled = true;
        speechBubble.transform.LookAt(mainCamera, Vector3.up);
    }

    void OnMouseExit()
    {
        speechBubble.enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Kicking", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Kicking", false);
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            animator.SetBool("Kicking2", true);
        }
        else if (Input.GetKeyUp(KeyCode.RightShift))
        {
            animator.SetBool("Kicking2", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("Dancing2", true);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            animator.SetBool("Dancing2", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetBool("Dancing3", true);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            animator.SetBool("Dancing3", false);
        }
    }
}
