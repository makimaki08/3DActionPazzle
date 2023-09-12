using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject textClear;
    public GameObject textFailed;
    // ?????????
    private bool isStageEnd;

    // Start is called before the first frame update
    void Start()
    {
        textClear.SetActive(false);
        textFailed.SetActive(false);
        isStageEnd = false;
    }

    void Update()
    {
        // ????????????????????????????????????
        if (isStageEnd && (Input.GetKey(KeyCode.Mouse0) || Input.touchCount>0))
        {
            // ???MEnu??????
            //Application.LoadLevel("Menu"); // Unity5.2????
            SceneManager.LoadScene("Menu");
        }
    }

    void StageClear()
    {
        textClear.SetActive(true);
        isStageEnd = true;
    }

    void StageFailed()
    {
        textFailed.SetActive(true);
        isStageEnd = false;
    }
}
