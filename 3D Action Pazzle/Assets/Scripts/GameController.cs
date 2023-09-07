using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject textClear;
    public GameObject textFailed;

    // Start is called before the first frame update
    void Start()
    {
        textClear.SetActive(false);
        textFailed.SetActive(false);
    }

    void StageClear()
    {
        textClear.SetActive(true);
    }

    void StageFailed()
    {
        textFailed.SetActive(true);
    }
}
