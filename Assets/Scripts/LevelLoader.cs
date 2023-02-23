using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string sceneName;
    public Animator crossFade;
    public float transtionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(sceneName));
    }
    IEnumerator LoadLevel(string name)
    {
        crossFade.SetTrigger("Start");
        yield return new WaitForSeconds(transtionTime);
        SceneManager.LoadScene(name);

    }
}
