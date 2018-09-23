using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform shipTransform; // Model's transform is off -_-
    [SerializeField] float rotationalDamp = 0.5f;
    [SerializeField] float movementSpeed = 10f;

    [SerializeField] float detectionDistance = 20f;
    [SerializeField] float rayCastOffset = 5f;

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
        Move();
        Pathfinding();
    }

    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(-pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position -= transform.forward * movementSpeed * Time.deltaTime;
    }

    void Pathfinding()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = shipTransform.position + shipTransform.right * rayCastOffset;
        Vector3 right = shipTransform.position - shipTransform.right * rayCastOffset;
        Vector3 up = shipTransform.position + shipTransform.up * rayCastOffset;
        Vector3 down = shipTransform.position - shipTransform.up * rayCastOffset;

        //Debug.DrawRay(left, -shipTransform.forward * detectionDistance, Color.cyan);
        //Debug.DrawRay(right, -shipTransform.forward * detectionDistance, Color.cyan);
        //Debug.DrawRay(up, -shipTransform.forward * detectionDistance, Color.cyan);
        //Debug.DrawRay(down, -shipTransform.forward * detectionDistance, Color.cyan);

        if (Physics.Raycast(left, shipTransform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.right;
        }
        else if (Physics.Raycast(right, shipTransform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.right;
        }

        if (Physics.Raycast(up, shipTransform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.up;
        }
        else if (Physics.Raycast(down, shipTransform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.up;
        }

        if (raycastOffset != Vector3.zero)
        {
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        }
        else
        {
            Turn();
        }
    }
}
