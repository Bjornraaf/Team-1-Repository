using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapSceneWorm : MonoBehaviour
{
    //[Header("Animator")]
    //[SerializeField] private Animator DTransition;
    [SerializeField] private LevelLoader DLoader;
    public void LoadGPS()
    {
        //StartCoroutine(DLoadLevel());
    }
    //IEnumerator DLoadLevel()
    //{
        //DTransition.SetTrigger("Start");
        //yield return new WaitForSeconds(1);
        //yield return null;
    //    SceneManager.LoadScene("GPS");
    //}
    public void NextGame(string SceneName)
    {
        DLoader.loadSceneWithName = SceneName;
        DLoader.LoadNextLevel();
    }
}
