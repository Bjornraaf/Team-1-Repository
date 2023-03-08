using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator Transition;
    [Header("Variables")]
    [SerializeField] private float TransitionTime = 1f;
    public string loadSceneWithName;

    /// <summary>
    /// Starts the Scene Transition and Loads the next Scene;
    /// </summary>
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(loadSceneWithName));
    }
    IEnumerator LoadLevel(string name)
    {
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(name);

    }
}
