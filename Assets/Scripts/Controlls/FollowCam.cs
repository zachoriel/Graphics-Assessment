using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultPosition = new Vector3(0f, 0f, 0f);
    [SerializeField] float distanceDamp = 10f;

    Transform myTransform;

    public Vector3 velocity = Vector3.one;

	void Awake ()
    {
        myTransform = GetComponent<Transform>();
    }
	
	void LateUpdate ()
    {
        SmoothFollow();
	}

    void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultPosition);
        Vector3 currentPos = Vector3.SmoothDamp(myTransform.position, toPos, ref velocity, distanceDamp);
        myTransform.position = currentPos;

        myTransform.LookAt(target, target.up);
    }
}
