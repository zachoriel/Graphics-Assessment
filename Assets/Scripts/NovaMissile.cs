using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaMissile : MonoBehaviour
{
    public ParticleSystem novaImplode, novaExplode;

    ActiveTargets targets;
    MissileLauncher launcher;
    Rigidbody rb;
    MeshRenderer meshRenderer;

    void Awake()
    {
        targets = FindObjectOfType<ActiveTargets>();
        launcher = FindObjectOfType<MissileLauncher>();
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();

        rb.AddForce(launcher.firePoint.transform.forward * launcher.launchForce, ForceMode.Impulse);

        StartCoroutine(TimeBomb());
    }

    IEnumerator TimeBomb()
    {
        yield return new WaitForSeconds(7f);
        Explode();

        yield return new WaitForSeconds(5.5f);
        CleanUp();

        yield break;
    }

    IEnumerator CollisionCleanUp()
    {
        yield return new WaitForSeconds(5.5f);
        CleanUp();

        yield break;
    }

    public void Explode()
    {
        this.meshRenderer.enabled = false;
        novaImplode.Play();
        novaExplode.Play();
    }

    public void CleanUp()
    {
        StopCoroutine(TimeBomb());
        StopCoroutine(CollisionCleanUp());
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider != null && other.collider.gameObject.tag != "Player")
        {
            StopCoroutine(TimeBomb());
            Explode();

            StartCoroutine(CollisionCleanUp());
        }

        if (other.collider.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);

            targets.activeTargets = GameObject.FindGameObjectsWithTag("Target");
            targets.activeTargetsText.text = "Active Targets: " + targets.activeTargets.Length.ToString();

            if (targets.activeTargets.Length > 66)
            {
                targets.activeTargetsText.color = Color.red;
            }
            else if (targets.activeTargets.Length > 33 && targets.activeTargets.Length <= 66)
            {
                targets.activeTargetsText.color = Color.yellow;
            }
            else if (targets.activeTargets.Length < 33)
            {
                targets.activeTargetsText.color = Color.green;
            }
        }
    }
}
