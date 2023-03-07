using UnityEngine;
using System.Collections;

public class RandomAnimationPlayer : MonoBehaviour
{
    public float minDelay = 1f;
    public float maxDelay = 5f;

    private Animator anim;
    private bool isPlaying = false;

    private int randomAnimsLayerIndex = 0; // index of the "RandomAnims" layer in the Animator

    private void Start()
    {
        anim = GetComponent<Animator>();
        randomAnimsLayerIndex = anim.GetLayerIndex("RandomAnims"); // get the index of the "RandomAnims" layer
        StartCoroutine(PlayRandomAnimation());
    }

    IEnumerator PlayRandomAnimation()
    {
        while (true)
        {
            if (!isPlaying)
            {
                // Choose a random clip to play
                int clipIndex = Random.Range(0, anim.runtimeAnimatorController.animationClips.Length);
                AnimationClip clip = anim.runtimeAnimatorController.animationClips[clipIndex];

                // Play the clip on the "RandomAnims" layer
                anim.PlayInFixedTime(clip.name, randomAnimsLayerIndex);

                // Set a random delay until the next clip plays
                float delay = Random.Range(minDelay, maxDelay);
                yield return new WaitForSeconds(delay);
            }
            else
            {
                // Wait for the current animation to finish playing
                yield return null;
            }
        }
    }

    private void Update()
    {
        // Check if the current animation is still playing on the "RandomAnims" layer
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(randomAnimsLayerIndex);
        isPlaying = state.normalizedTime < 1.0f;
    }
}
