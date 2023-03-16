using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class RaycastForBee : MonoBehaviour
{
    [SerializeField] private GameObject Bee;
    [SerializeField] private GameObject Flower;


    void Update ()
    {
        RaycastHit BeerayHit;

        //Checks if the raycast hits the wall.
        if (Physics.Raycast(Bee.transform.position, Bee.transform.forward, out BeerayHit))
        {
            if (BeerayHit.transform.tag == "Flower")
            {
                Debug.Log("hitted flower");
            }
        }
    }

}