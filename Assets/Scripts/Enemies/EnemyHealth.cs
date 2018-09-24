using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    private float startHealth = 100f;
    TestyTest dissolve;

    // Use this for initialization
    void Start()
    {
        health = startHealth;

        dissolve = GetComponentInParent<TestyTest>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        health = Mathf.Clamp(health, 0f, 100f);
    }

    void OnCollisionEnter(Collision other)
    {
        TakeDamage(health);
    }

    void Update()
    {
        if (health <= 0)
        {
            dissolve.lerpTest += 0.55f * Time.deltaTime;

            if (dissolve.lerpTest >= 1.1f)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
