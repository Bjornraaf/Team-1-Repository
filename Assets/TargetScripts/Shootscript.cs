using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootscript : MonoBehaviour
{
    public GameObject ARCamera;
    public GameObject particle;

    public void shoot()
    {
            RaycastHit hit;
        
        if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit))
        {
            if (hit.transform.name == "Sphere 1(Clone)"    || hit.transform.name == "Sphere 2(Clone)"   || hit.transform.name == "Sphere(Clone)")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(particle, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
