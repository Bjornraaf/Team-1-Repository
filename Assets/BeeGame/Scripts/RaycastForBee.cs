using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class RaycastForBee : MonoBehaviour
{
    [SerializeField] private GameObject ARCamera;
    [SerializeField] private GameObject Bee;


    void Update ()
    {
        RaycastHit BeerayHit;

        //Checks if the raycast hits the wall.
        if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out BeerayHit))
        {
            if (BeerayHit.transform.tag == "Wall")
            {
                Bee.transform.position = BeerayHit.transform.position;
            }
        }
    }

}