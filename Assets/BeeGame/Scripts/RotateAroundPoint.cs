using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{

    [SerializeField] private float RotationSpeed;
    [SerializeField] private GameObject RotationCenter;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(RotationCenter.transform.position, new Vector3(0, 1, 0), RotationSpeed * Time.deltaTime);
    }
}
