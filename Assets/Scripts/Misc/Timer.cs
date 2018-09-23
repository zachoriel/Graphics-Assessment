using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timerText;
    ObjectSpawner spawner;
    [SerializeField] float time;
    GameObject[] enemies;
    bool enemiesAttacking;

	void Awake ()
    {
        timerText = GetComponent<Text>();
        spawner = FindObjectOfType<ObjectSpawner>();
        enemiesAttacking = false;

        StartCoroutine(Countdown());

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            var minutes = Mathf.Floor(time / 60);
            var seconds = time % 60;

            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
        else
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length > 0)
            {
                int numOfEnemies = enemies.Length;
                timerText.text = "Enemies: " + numOfEnemies.ToString();
            }
            else
            {
                KillTimer();
                return;
            }
        }  
	}

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(419.9f);
        spawner.GenerateEnemies();
        enemiesAttacking = true;
        yield break;
    }

    void KillTimer()
    {
        enemiesAttacking = false;
        Destroy(timerText);
    }
}
