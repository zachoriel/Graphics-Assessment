using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject asteroidOne, asteroidTwo, asteroidThree;

    public Vector3 center, size;

    int prefabIndex;

	// Use this for initialization
	void Start ()
    {
        prefabList.Add(asteroidOne);
        prefabList.Add(asteroidTwo);
        prefabList.Add(asteroidThree);

        for (int objectNumber = 0; objectNumber < 100; objectNumber++)
        {
            SpawnObjects();
        }
	}

    public void SpawnObjects()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        prefabIndex = Random.Range(0, 3);

        Instantiate(prefabList[prefabIndex], pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
