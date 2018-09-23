using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    Laser laser;

    Vector3 hitPosition;

    float damage;

    void Update()
    {
        InFront();
        HaveLineOfSight();

        if (InFront() && HaveLineOfSight() && Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }

    bool InFront()
    {
        Vector3 directionToTarget = firePoint.transform.position - target.position;
        float angle = Vector3.Angle(firePoint.transform.forward, directionToTarget);

        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            //Debug.DrawLine(transform.position, target.position, Color.green);
            return true;
        }

        //Debug.DrawLine(transform.position, target.position, Color.red);
        return false;
    }

    bool HaveLineOfSight()
    {
        RaycastHit hit;

        Vector3 direction = target.position - firePoint.transform.position;

        if (Physics.Raycast(laser.transform.position, direction, out hit, laser.Distance))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                //Debug.DrawRay(laser.transform.position, direction, Color.yellow);
                hitPosition = hit.transform.position;
                return true;
            }
        }

        return false;
    }

    void FireLaser()
    {
        laser.FireLaser(hitPosition);
    }
}
