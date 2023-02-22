using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargetScript : MonoBehaviour
{

    public Transform [] spawnPoints;
    public GameObject [] targets;
    public GameObject Endscreen;
    public int spawns = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
        StartCoroutine(ShowEnd());
    }

    public IEnumerator StartSpawning ()
    {

        yield return new WaitForSeconds(3);

        for (int i = 0; i < 3;   i++) 
        {
            Instantiate(targets[i], spawnPoints[i].position, Quaternion.identity);
            spawns += 1;
        }


        if (spawns <= 29)
        {
            StartCoroutine(StartSpawning());
        }

    }

    public IEnumerator ShowEnd ()
    {
        yield return new WaitForSeconds(40);
        Endscreen.SetActive(true);
    }

}
