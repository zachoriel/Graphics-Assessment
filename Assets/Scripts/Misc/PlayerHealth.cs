using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public GameObject deathEffect;
    public float health;
    float startHealth = 100f;
    double oneThirdHealth, twoThirdshealth;
    PlayerController controls;
    MissileLauncher weapons;
    MeshRenderer mesh;
    SceneFader sceneFader;
    [SerializeField] string menu;

	// Use this for initialization
	void Start ()
    {
        health = startHealth;
        healthText.text = "Health: " + health.ToString();

        oneThirdHealth = startHealth * 0.33f;
        twoThirdshealth = startHealth * 0.66f;

        controls = GetComponent<PlayerController>();
        weapons = GetComponent<MissileLauncher>();
        mesh = GetComponent<MeshRenderer>();
        sceneFader = FindObjectOfType<SceneFader>();
	}

    public void TakeDamage(float amount)
    {
        if (health > 0)
        {
            health -= amount;
            healthText.text = "Health: " + health.ToString();
        }
        else
        {
            healthText.text = "Health: 0";
        }

        health = Mathf.Clamp(health, 0f, 100f);
    }

    void DisableShip()
    {
        mesh.enabled = false;
        controls.enabled = false;
        weapons.enabled = false;
        gameObject.tag = "Untagged";

        Instantiate(deathEffect, transform.position, Quaternion.identity);

        sceneFader.FadeTo(menu);
    }

    void Update()
    {
        if (health <= 0)
        {
            DisableShip();          
        }

        if (health > twoThirdshealth)
        {
            healthText.color = Color.green;
        }
        else if (health > oneThirdHealth && health <= twoThirdshealth)
        {
            healthText.color = Color.yellow;
        }
        else if (health < oneThirdHealth)
        {
            healthText.color = Color.red;
        }
    }
}
