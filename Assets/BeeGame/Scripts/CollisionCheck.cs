using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] private int GrowScore1 = 0;
    [SerializeField] private int GrowScore2 = 0;
    [SerializeField] private int GrowScore3 = 0;
    IEnumerator ScoreCount1()
    {
        yield return new WaitForSeconds(1);
        GrowScore1 += 1;
        StartCoroutine(ScoreCount1());
    }

    IEnumerator ScoreCount2()
    {
        yield return new WaitForSeconds(1);
        GrowScore2 += 1;
        StartCoroutine(ScoreCount2());
    }

    IEnumerator ScoreCount3()
    {
        yield return new WaitForSeconds(1);
        GrowScore3 += 1;
        StartCoroutine(ScoreCount3());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("flower"))
        {
            StartCoroutine(ScoreCount1());
        }

        if (other.gameObject.name.Equals("flower1"))
        {
            StartCoroutine(ScoreCount2());
        }

        if (other.gameObject.name.Equals("flower2"))
        {
            StartCoroutine(ScoreCount3());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("flower"))
        {
            StopAllCoroutines();
        }

        if (other.gameObject.name.Equals("flower1"))
        {
            StopAllCoroutines();
        }

        if (other.gameObject.name.Equals("flower2"))
        {
            StopAllCoroutines();
        }

    }

    private void Update()
    {
        if ( GrowScore1 >= 2 && GrowScore2 >= 2 && GrowScore3 >= 2)
        {
         
        }
    }
}
