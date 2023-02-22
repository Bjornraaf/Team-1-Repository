using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Shootscript : SpawnTargetScript
{
    public GameObject ARCamera;
    public GameObject particle;
    public Text scoretext;
    public Text scoretext2;
    public int score = 0;

    public void shoot()
    {
            RaycastHit hit;
        
        if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit))
        {
            if (hit.transform.name == "seed(Clone)"    || hit.transform.name == "Sphere 2(Clone)"   || hit.transform.name == "Sphere(Clone)")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(particle, hit.point, Quaternion.LookRotation(hit.normal));
                score += 1;
                scoretext.text = score.ToString() + " Points";
                scoretext2.text = score.ToString() + " Points";
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
