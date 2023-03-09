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
   public Quaternion centerPivotCam;
   private bool gyroEnabled;
   private Gyroscope gyro;
   
   private void Start()
   {
      // Check if gyro is supported
      gyroEnabled = SystemInfo.supportsGyroscope;

      // Enable gyro if supported
      if (gyroEnabled)
      {
         gyro = Input.gyro;
         gyro.enabled = true;
      }
      else
      {
         Debug.LogError("Gyro is not supported on this device!");
      }
   }
   
   void Update()
   {
      // Get the rotation rate from the gyroscope
      Vector3 rotationRate = Input.gyro.rotationRateUnbiased;
      centerPivotCam = Quaternion.Euler(0, rotationRate.y, 0);
      cameraRot.transform.rotation = centerPivotCam;
      
      // Rotate camera using gyro if enabled
      if (gyroEnabled)
      {
         transform.rotation = gyro.attitude;
      }
      
      Debug.Log(rotationRate);
      Debug.Log(centerPivotCam);
      Debug.Log(cameraRot);
   }
}
