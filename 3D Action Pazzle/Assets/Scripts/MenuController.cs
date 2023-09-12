using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnClickMenuButton(string scene)
    {
        //Application.LoadLevel(scene); // Unity5.2で非推奨のやり方
        SceneManager.LoadScene(scene);
    }
}
