using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaMissile : MonoBehaviour
{
    // Supernovae impact particle effects
    public ParticleSystem novaImplode, novaExplode;

    // Components and scripts
    ActiveTargets targets;
    MissileLauncher launcher;
    Rigidbody rb;
    MeshRenderer meshRenderer; // For disabling the missile object's mesh renderer while the childed particle systems play

    void Awake()
    {
        targets = FindObjectOfType<ActiveTargets>();
        launcher = FindObjectOfType<MissileLauncher>();
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();

        // Adds a force to the missile object after it's fired (done in the MissileLauncher script)
        rb.AddForce(launcher.firePoint.transform.forward * launcher.launchForce, ForceMode.Impulse);

        StartCoroutine(TimeBomb());
    }

    // Basically makes the missile object a time bomb
    IEnumerator TimeBomb()
    {
        // Missile object will explode and play the supernovae particle systems after x seconds
        yield return new WaitForSeconds(7f);
        Explode();

        // Destroys the missile object & the particle systems after they've finished playing (adjust time if particle system duration is changed)
        yield return new WaitForSeconds(5.5f);
        CleanUp();

        yield break;
    }

    // Only called if the missile object collides with something
    IEnumerator CollisionCleanUp()
    {
        // Destroys the missile object & the particle systems after they've finished playing (adjust time if particle system duration is changed)
        yield return new WaitForSeconds(5.5f);
        CleanUp();

        yield break;
    }

    // Makes the missile object invisible & plays the supernovae particle systems
    public void Explode()
    {
        this.meshRenderer.enabled = false;
        novaImplode.Play();
        novaExplode.Play();
    }

    // Stops all coroutines and destroys the missile object & the particle systems
    public void CleanUp()
    {
        StopCoroutine(TimeBomb());
        StopCoroutine(CollisionCleanUp());
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision other)
    {
        // If the missile object collides with something other than the player
        if (other.collider != null && other.collider.gameObject.tag != "Player")
        {
            // Stops the time bomb
            StopCoroutine(TimeBomb());
            // Plays the supernovae effects
            Explode();

            // Begins clean-up timer
            StartCoroutine(CollisionCleanUp());
        }

        // If the missile object collides with an asteroid target
        if (other.collider.gameObject.tag == "Target")
        {
            // Destroys the asteroid
            Destroy(other.gameObject);

            // If the player has destroyed less than 33% of the asteroids, UI is red
            if (targets.activeTargets.Length > 66)
            {
                targets.activeTargetsText.color = Color.red;
            }
            // If the player has destroyed between 33% and 66% of the asteroids, UI is yellow
            else if (targets.activeTargets.Length > 33 && targets.activeTargets.Length <= 66)
            {
                targets.activeTargetsText.color = Color.yellow;
            }
            // If the player has destroyed greater than 66% of the asteroids, UI is green
            else if (targets.activeTargets.Length <= 33)
            {
                targets.activeTargetsText.color = Color.green;
            }
        }
    }
}
