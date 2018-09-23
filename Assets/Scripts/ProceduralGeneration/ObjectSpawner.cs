using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject asteroidOne, asteroidTwo, asteroidThree, asteroidParent;

    public GameObject enemy, enemyParent;

    public Vector3 center, size;

    public bool inMenu;

    int prefabIndex;

    [SerializeField] int totalAsteroids;
    [SerializeField] int totalEnemies;

	// Use this for initialization
	void Start ()
    {
        prefabList.Add(asteroidOne);
        prefabList.Add(asteroidTwo);
        prefabList.Add(asteroidThree);

        if (inMenu == false)
        {
            totalAsteroids = Random.Range(3, 101);
        }

        for (int objectNumber = 0; objectNumber < totalAsteroids; objectNumber++)
        {
            SpawnObjects();
        }
	}

    public void GenerateEnemies()
    {
        for (int enemyNumber = 0; enemyNumber < totalEnemies; enemyNumber++)
        {
            SpawnEnemies();
        }
    }

    public void SpawnObjects()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        prefabIndex = Random.Range(0, 3);

        Instantiate(prefabList[prefabIndex], pos, Quaternion.identity, asteroidParent.transform);
    }

    public void SpawnEnemies()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(enemy, pos, Quaternion.identity, enemyParent.transform);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
