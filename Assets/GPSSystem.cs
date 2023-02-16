using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GPSSystem : MonoBehaviour
{
    Vector2 r_Init;
    Vector2 r_CurrentPostion;
    Vector2 f_Init;
    Vector2 f_CurrentPostion;

    public float scale;
    public bool isFakingLocation;

    private void Start()
    {
        Input.location.Start( 2.5f, 2.5f);
        Input.compass.enabled = true;
    }
    IEnumerator UpdatePostion()
    {
        if (isFakingLocation == false)
        {
            if (Input.location.isEnabledByUser == false)
            {
                GameObject.Find("FailedText").GetComponent<Text>().text = "Failed because Location was not enabled.";
            }

            int maxWait = 20;

            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            if (maxWait < 1)
            {
                GameObject.Find("FailedText").GetComponent<Text>().text = "Initializing failed, try again.";
                yield return null;
            }
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                GameObject.Find("FailedText").GetComponent<Text>().text = "Location service status failed";
                //Debug.Log("Location service status failed");
                yield return null;
            }
            else
            {
                if (r_Init == Vector2.zero)
                {
                    r_Init = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
                }
                SetLocation(Input.location.lastData.latitude, Input.location.lastData.longitude);
            }
        }
        else
        {
            SetLocation(100 + Time.time, 100 + Time.time);
        }
    }
    void SetLocation(float latitude, float longitude)
    {
        r_CurrentPostion = new Vector2(latitude, longitude);
        Vector2 delta = new Vector2(r_CurrentPostion.x - r_Init.x, r_CurrentPostion.y - r_Init.y);
        f_CurrentPostion = delta * scale;
        transform.position = new Vector3(f_CurrentPostion.x, 0, f_CurrentPostion.y);
        GameObject.Find("PositionText").GetComponent<Text>().text = transform.position.x + " : " + transform.position.y + " : " + transform.position.z;
    }
    private void Update()
    {
        StartCoroutine(UpdatePostion());
    }

}
