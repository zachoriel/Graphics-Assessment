using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour, IPooledObject
{
    [Header("Components")]
    public MeshRenderer meshRenderer;
    public GameObject explosionPrefab;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnObjectSpawn()
    {
        gameObject.SetActive(true);
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider != null)
        {
            GameObject explosionObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosionObject, 2f);
            gameObject.SetActive(false);
        }
    }
}
