using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject missile, firePoint;
    public Rigidbody missileRB;
    public float launchForce = 5f;

	// Use this for initialization
	void Start ()
    {
		if (missile.GetComponent<Rigidbody>() == null)
        {
            missile.AddComponent<Rigidbody>();
        }
	}

    void FireMissile()
    {
        Instantiate(missile, firePoint.transform.position, firePoint.transform.rotation);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            FireMissile();
        }
	}
}
