using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///----------------------------------------$$$$$$$\   $$$$$$\  $$$$$$$\   $$$$$$\  
///----------------------------------------$$  __$$\ $$  __$$\ $$  __$$\ $$$ __$$\ 
///----------------------------------------$$ |  $$ |$$ /  $$ |$$ |  $$ |$$$$\ $$ |
///----------Author------------------------$$$$$$$  |$$$$$$$$ |$$$$$$$  |$$\$$\$$ |
///----------Patryk Podworny---------------$$  ____/ $$  __$$ |$$  ____/ $$ \$$$$ |
///----------------------------------------$$ |      $$ |  $$ |$$ |      $$ |\$$$ |
///----------------------------------------$$ |      $$ |  $$ |$$ |      \$$$$$$  /
///----------------------------------------\__|      \__|  \__|\__|       \______/ 

public class WormMover : MonoBehaviour
{
   public Transform cameraRot;
   public Quaternion centerPivotWorm;
   public float smoothRotation;
   public float cameraRotation;
   [Tooltip("The Compass Script")]
   [SerializeField] private CompassController _compassController;
   [Tooltip("The amount of noise filtering for the rotation ")]
   public float filterFactor = 0.05f;

   void Start()
   {
      cameraRotation = cameraRot.rotation.y;
   }

   void Update()
   {
      // Apply a low-pass filter to smooth out the heading value.
      smoothRotation = Mathf.LerpAngle(smoothRotation, cameraRotation, filterFactor);
      centerPivotWorm = Quaternion.Euler(0, smoothRotation, 0);
   }
}
