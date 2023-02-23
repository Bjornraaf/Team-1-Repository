using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargetScript : MonoBehaviour
{

    [SerializeField] private Transform [] SpawnPoints;
    [SerializeField] private GameObject [] Targets;
    [SerializeField] private GameObject EndScreen;
     private int Spawns = 0;

    // Start is called before the first frame update.
    void Start()
    {
        StartCoroutine(StartSpawning());
        StartCoroutine(ShowEnd());
    }

    // the entire script that makes the leaves spawn after an interval.
    IEnumerator StartSpawning () 
    {

        yield return new WaitForSeconds(3);

        for (int i = 0; i < 3;   i++) 
        {
            Instantiate(Targets[i], SpawnPoints[i].position, Quaternion.identity);
            Spawns += 1;
        }

        // Starts and stops the leaves from spawning.
        if (Spawns <= 29)
        {
            StartCoroutine(StartSpawning());
        }

    }

    //This shows the end screen after 40 seconds.
    IEnumerator ShowEnd () 
    {
        yield return new WaitForSeconds(40);
        EndScreen.SetActive(true);
    }

}
