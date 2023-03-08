using UnityEngine;
using UnityEngine.UI;


public class Waypoint : MonoBehaviour
{
    [SerializeField] private LevelLoader Loader;
    [SerializeField] private string NewSceneName;
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Loader.LoadSceneWithName = NewSceneName;
        Loader.LoadNextLevel();
    }
}
