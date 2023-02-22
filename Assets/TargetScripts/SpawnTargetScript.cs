using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargetScript : MonoBehaviour
{

    [SerializeField] private Transform [] SpawnPoints;
    [SerializeField] private GameObject [] Targets;
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private int Spawns = 0;

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
            Instantiate(Targets[i], SpawnPoints[i].position, Quaternion.identity);
            Spawns += 1;
        }


        if (Spawns <= 29) // stops the leaves from spawning
        {
            StartCoroutine(StartSpawning());
        }

    }

     IEnumerator ShowEnd () //this shows the end screen after 40 seconds
    {
        yield return new WaitForSeconds(40);
        EndScreen.SetActive(true);
    }

}
