using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Animator")]
    //[SerializeField] private Animator Transition;
    [Header("Variables")]
    [SerializeField] private float TransitionTime = 1f;
    public string loadSceneWithName;
    public EndScore endScore;

    /// <summary>
    /// Starts the Scene Transition and Loads the next Scene;
    /// </summary>

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(loadSceneWithName));
        Debug.Log("loading scene");
    }
    
    IEnumerator LoadLevel(string name)
    {
        Debug.Log("ienumarator used");
        //Transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(name);
    }
}
