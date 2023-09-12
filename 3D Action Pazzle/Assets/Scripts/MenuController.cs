using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    void OnClickMenuButton(string scene)
    {
        Application.LoadLevel(scene);
    }
}
