using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

///----------------------------------------$$$$$$$\   $$$$$$\  $$$$$$$\   $$$$$$\  
///----------------------------------------$$  __$$\ $$  __$$\ $$  __$$\ $$$ __$$\ 
///----------------------------------------$$ |  $$ |$$ /  $$ |$$ |  $$ |$$$$\ $$ |
///----------Author------------------------$$$$$$$  |$$$$$$$$ |$$$$$$$  |$$\$$\$$ |
///----------Patryk Podworny---------------$$  ____/ $$  __$$ |$$  ____/ $$ \$$$$ |
///----------------------------------------$$ |      $$ |  $$ |$$ |      $$ |\$$$ |
///----------------------------------------$$ |      $$ |  $$ |$$ |      \$$$$$$  /
///----------------------------------------\__|      \__|  \__|\__|       \______/ 

public class AskForPermission : MonoBehaviour
{
    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            Permission.RequestUserPermission(Permission.FineLocation);
        if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
            Permission.RequestUserPermission(Permission.CoarseLocation);
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            Permission.RequestUserPermission(Permission.Camera);
    }
}
