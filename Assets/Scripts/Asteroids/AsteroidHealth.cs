using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class AsteroidHealth : MonoBehaviour
{
    public float health;
    private float startHealth = 100;
    public Material baseMat;
    public Material burnMat;
    TestyTest dissolve;

	// Use this for initialization
	void Start ()
    {
        health = startHealth;

        GetComponentInChildren<Renderer>().material = baseMat;

        dissolve = GetComponentInChildren<TestyTest>();
	}

    public void TakeDamage(float amount)
    {
        health -= amount;

        health = Mathf.Clamp(health, 0f, 100f);
    }

    private void Update()
    {
        if (health <= 0)
        {
            dissolve.lerpTest += 0.2f * Time.deltaTime;

            if (dissolve.lerpTest >= 0.9f)
            {
                Destroy(gameObject);
            }
        }
    }
}
