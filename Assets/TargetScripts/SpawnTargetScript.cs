using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargetScript : MonoBehaviour
{

    public  Transform [] spawnPoints;
     public GameObject [] targets;
    public GameObject endScreen;
     int spawns = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
        StartCoroutine(ShowEnd());
    }

    IEnumerator StartSpawning () // the entire script that makes the leaves spawn after an interval
    {

        yield return new WaitForSeconds(3);

        for (int i = 0; i < 3;   i++) 
        {
            Instantiate(targets[i], spawnPoints[i].position, Quaternion.identity);
            spawns += 1;
        }


        if (spawns <= 29) // stops the leaves from spawning
        {
            StartCoroutine(StartSpawning());
        }

    }

     IEnumerator ShowEnd () //this shows the end screen after 40 seconds
    {
        yield return new WaitForSeconds(40);
        endScreen.SetActive(true);
    }

}
