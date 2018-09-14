using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject muzzleFlash;
    public GameObject impactEffect;
    public float speed = 60f;
    TestyTest dissolve;

	// Use this for initialization
	void Awake ()
    {
        dissolve = FindObjectOfType<TestyTest>();

        GameObject muzzle = Instantiate(muzzleFlash, transform.position, Quaternion.identity);
        Destroy(muzzle, 2f);

        Destroy(gameObject, 20f);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (speed > 0)
        {
            transform.position += (transform.forward) * (speed * Time.deltaTime);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if (other.gameObject.tag != "Player")
        {
            GameObject impact = Instantiate(impactEffect, pos, rot);
            Destroy(impact, 5f);
            Destroy(gameObject, 13);

            if (other.gameObject.tag == "Target")
            {
                Destroy(gameObject);
                //StartCoroutine(DissolveAsteroid());
            }
        }
    }

    IEnumerator DissolveAsteroid()
    {
        dissolve.lerpTest += 0.1f;
        yield return new WaitForEndOfFrame();

        if (dissolve.lerpTest == 1.1f)
        {
            yield break;
        }
    }
}
