using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform firePoint;
    [SerializeField] Laser laser;

    Vector3 hitPosition;
    GameObject player, bob;

    public bool inMenu;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bob = GameObject.FindGameObjectWithTag("BOB");

        if (inMenu == false)
        {
            target = player.gameObject.transform;
        }
        else
        {
            target = bob.gameObject.transform;
        }
    }

    void Update()
    {
        InFront();
        HaveLineOfSight();

        if (InFront() && HaveLineOfSight())
        {
            FireLaser();
        }
    }

    bool InFront()
    {
        Vector3 directionToTarget = firePoint.transform.position - target.position;
        float angle = Vector3.Angle(firePoint.transform.forward, directionToTarget);

        if (Mathf.Abs(angle) > 0 && Mathf.Abs(angle) < 70)
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
            if (hit.transform.CompareTag("Player"))
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
