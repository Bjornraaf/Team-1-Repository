using UnityEngine;

public class SwapSceneWorm : MonoBehaviour
{
    [SerializeField] private LevelLoader SceneLoader;  
    public void NextGame(string SceneName)
    {
        SceneLoader.loadSceneWithName = SceneName;
        SceneLoader.LoadNextLevel();
    }
}
