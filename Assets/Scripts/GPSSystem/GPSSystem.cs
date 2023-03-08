using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GPSSystem : MonoBehaviour
{
    private Vector2 RealInit;
    private Vector2 RealCurrentPostion;
    private Vector2 FakeCurrentPostion;

    [Header("Scaling")]
    [SerializeField] private float Scale;
    [Header("Test Location")]
    [SerializeField] private bool isFakingLocation;

    private void Start()
    {
        Input.location.Start( 5, 10);
        Input.compass.enabled = true;
    }
    /// <summary>
    /// Holds all the failsafes for the game and the Fakelocation game tester.
    /// </summary>
    /// <returns> a new Setlocation every amount of meters defined by the Input.location.Start </returns>
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
                yield return null;
            }
            else
            {
                if (RealInit == Vector2.zero)
                {
                    RealInit = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
                }
                SetLocation(Input.location.lastData.latitude, Input.location.lastData.longitude);
            }
        }
        else
        {
            SetLocation(0 + -Time.time, 0 + -Time.time);
        }
    }

    /// <summary>
    /// Sets the postion of the player to a new location.
    /// </summary>
    /// <param name="latitude">Latitude is a coordinate that specifies the North–South position of a point on the surface of the Earth</param>
    /// <param name="longitude">Longitude is a coordinate that specifies the East-West position of a point on the surface of the Earth</param>
    void SetLocation(float latitude, float longitude)
    {
        RealCurrentPostion = new Vector2(latitude, longitude);
        Vector2 delta = new Vector2(RealCurrentPostion.x - RealInit.x, RealCurrentPostion.y - RealInit.y);
        FakeCurrentPostion = delta * Scale;
        transform.position = new Vector3(FakeCurrentPostion.x, 0, FakeCurrentPostion.y);
        GameObject.Find("PositionText").GetComponent<Text>().text = transform.position.x + " : " + transform.position.y + " : " + transform.position.z;
    }
    private void Update()
    {
        StartCoroutine(UpdatePostion());
    }
}
