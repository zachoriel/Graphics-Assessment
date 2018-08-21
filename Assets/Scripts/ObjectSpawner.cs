using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
        objectPooler = ObjectPooler.Instance;
        gameManager = FindObjectOfType<GameManager>();
	}
	
	public void GrenadeSpawn()
    {
        objectPooler.SpawnFromPool("Grenade", gameManager.grenadeSpawnPoint.transform.position, Quaternion.identity);
    }
}
