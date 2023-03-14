using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTest : MonoBehaviour
{
    [SerializeField] private LevelLoader Loader;
    [SerializeField] private GameObject locationUI;
    private bool isOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        locationUI.SetActive(isOn);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && isOn == false)
        {
            Touch touch = Input.GetTouch(1);
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    isOn = true;
                    locationUI.SetActive(isOn);
                    break;

                //Determine if the touch is a moving touch
                //case TouchPhase.Moved:
                // Determine direction by comparing the current touch position with the initial one
                //direction = touch.position - startPos;
                //Debug.Log("Moved");
                //break;

                case TouchPhase.Ended:
                    Debug.Log("Ended");
                    break;
            }
        }
        else if (Input.touchCount > 0 && isOn == true)
        {
            Touch touch = Input.GetTouch(1);
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    isOn = false;
                    locationUI.SetActive(isOn);
                    break;

                case TouchPhase.Ended:
                    Debug.Log("Ended");
                    break;
            }
        }
    }
    public void NextGame(string SceneName)
    {
        Loader.loadSceneWithName = SceneName;
        Loader.LoadNextLevel();
    }
}
