using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject novaeBomb, /*altNovaeBomb,*/ bullet, altBullet, laser, /*altLaser,*/ firePoint;
    public float launchForce = 5f;
    public bool alternateProjectileColors;

	// Use this for initialization
	void Start ()
    {
        alternateProjectileColors = false;
    }

    void FireBullet()
    {
        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
    }

    void FireAltBullet()
    {
        Instantiate(altBullet, firePoint.transform.position, firePoint.transform.rotation);
    }

    void FireLaser()
    {
        Instantiate(laser, firePoint.transform.position, firePoint.transform.rotation);
    }

    void FireNovaeBomb()
    {
        Instantiate(novaeBomb, firePoint.transform.position, firePoint.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && alternateProjectileColors == false)
        {
            FireBullet();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && alternateProjectileColors == true)
        {
            FireAltBullet();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && alternateProjectileColors == false)
        {
            FireLaser();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && alternateProjectileColors == false)
        {
            FireNovaeBomb();
        }
	}

    public void ToggleColors()
    {
        if (alternateProjectileColors == false)
        {
            alternateProjectileColors = true;
        }
        else
        {
            alternateProjectileColors = false;
        }
    }
}