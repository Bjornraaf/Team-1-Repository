using UnityEngine;


public class Waypoint : MonoBehaviour
{
    [SerializeField] private LevelLoader Loader;

    private void OnTriggerEnter(Collider other)
    {
        Loader.LoadNextLevel();
    }
}
