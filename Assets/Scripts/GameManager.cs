using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ObjectSpawner objectSpawner;
    public Camera topDownCam;
    public GameObject grenadeSpawnPoint, grenadeObject;

	// Use this for initialization
	void Start ()
    {
        if (objectSpawner == null)
        {
            objectSpawner = GetComponent<ObjectSpawner>();
        }

        if (grenadeSpawnPoint.transform.parent == null)
        {
            grenadeSpawnPoint.transform.parent = topDownCam.gameObject.transform;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.G) && topDownCam.enabled)
        {
            objectSpawner.GrenadeSpawn();
        }
	}
}
