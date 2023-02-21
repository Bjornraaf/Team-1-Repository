using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    IEnumerator disableObjectAfterSeconds()
    {
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

       StartCoroutine(disableObjectAfterSeconds());

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 0.2f);
        
    }
}
