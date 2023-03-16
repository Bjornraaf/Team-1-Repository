using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;

    IEnumerator playShortly()
    {
        animator.enabled = true;
        yield return new WaitForSeconds (1);
        animator.enabled = false;
    }

    private void Start()
    {
        animator.enabled = false;
        StartCoroutine(playShortly());
    }

    void Update()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Beam"))
        {
            animator.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Beam"))
        {
           animator.enabled = false;

        }
    }
}
