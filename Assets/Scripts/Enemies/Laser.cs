using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserOffTime = 0.5f;
    [SerializeField] float maxDistance = 300f;
    [SerializeField] float fireDelay = 2f;
    [SerializeField] float damage = 2f;

    PlayerHealth player;
    LineRenderer lineRenderer;
    bool canFire;

    void Awake()
    {
        player = FindObjectOfType<PlayerHealth>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        lineRenderer.enabled = false;
        canFire = true;
    }

    Vector3 CastRay()
    {
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            return hit.point;
        }

        return transform.position + (transform.forward * maxDistance);
    }

    public void FireLaser(Vector3 targetPosition)
    {
        if (canFire)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, targetPosition);
            lineRenderer.enabled = true;
            canFire = false;
            Invoke("TurnOffLaser", laserOffTime);
            Invoke("CanFire", fireDelay);

            player.TakeDamage(damage);
        }
    }

    void TurnOffLaser()
    {
        lineRenderer.enabled = false;
    }

    void CanFire()
    {
        canFire = true;
    }

    public float Distance
    {
        get { return maxDistance; }
    }

    public float Damage
    {
        get { return damage; }
    }
}
