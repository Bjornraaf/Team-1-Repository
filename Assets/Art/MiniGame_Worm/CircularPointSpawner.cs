using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class CircularPointSpawner : MonoBehaviour
{
    public Animator wormAnimator;
    public GameObject[] objectPrefabs;
    public int numberOfObjects = 10;
    public float radius = 5f;
    public float speed = 1f;
    public float spawnInterval = 1f;
    public bool spawnOnStart = true;
    public float maxHeight = 10f;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    public GameObject player;
    public float speedIncreaseInterval = 10f;
    public float speedIncreaseAmount = 0.5f;
    private float TimeSinceLastSpeedIncrease = 0f;

    private void Start()
    {
        // Find the BoxCollider on the player object
        BoxCollider playerCollider = player.GetComponent<BoxCollider>();

        // Throw an error if the player doesn't have a BoxCollider component
        if (playerCollider == null)
        {
            Debug.LogError("No BoxCollider found on player object!");
            return;
        }

        // If the player has a BoxCollider, we can proceed with the game
        if (spawnOnStart)
        {
            InvokeRepeating("SpawnObject", 0f, spawnInterval);
        }
    }

    private void SpawnObject()
    {
        // Choose a random angle around the circle
        float angle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate the position of the object at that angle
        Vector3 position = new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius);

        // Calculate the rotation of the object based on its position on the circle
        Quaternion rotation = Quaternion.LookRotation(transform.position - position);

        // Randomize the scale of the object
        float randomScale = Random.Range(minScale, maxScale);

        // Instantiate a random object prefab and set its position, rotation, and scale
        GameObject obj = Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length)], position, rotation);
        obj.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        obj.transform.parent = transform;

        // Move the object upwards using code
        StartCoroutine(MoveObject(obj.transform, Vector3.up * speed, maxHeight));
    }

    private IEnumerator MoveObject(Transform objTransform, Vector3 direction, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = objTransform.position;
        Vector3 targetPosition = objTransform.position + direction;

        while (elapsedTime < duration)
        {
            objTransform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;

            // Check for intersection with player collider
            if (objTransform.GetComponent<Collider>().bounds.Intersects(player.GetComponent<Collider>().bounds))
            {
                wormAnimator.SetTrigger("Chomp");
                Debug.Log("Object collided with player!");
                Destroy(objTransform.gameObject);
                yield break;
            }

            if (objTransform.position.y > maxHeight)
            {
                Destroy(objTransform.gameObject);
                yield break;
            }

            // Increase speed of objects over time
            TimeSinceLastSpeedIncrease += Time.deltaTime;
            if (TimeSinceLastSpeedIncrease > speedIncreaseInterval)
            {
                speed += speedIncreaseAmount;
                TimeSinceLastSpeedIncrease = 0f;
            }

            yield return null;
        }

        objTransform.position = targetPosition;
        Destroy(objTransform.gameObject);
    }
}
