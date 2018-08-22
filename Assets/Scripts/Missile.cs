using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public ParticleSystem novaImplode, novaExplode;

    MissileLauncher launcher;
    Rigidbody rb;
    MeshRenderer meshRenderer;

    void Awake()
    {
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
        if (other.collider != null)
        {
            StopCoroutine(TimeBomb());
            Explode();

            StartCoroutine(CollisionCleanUp());
        }
    }
}
