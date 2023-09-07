using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    // GameController
    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        // シーンからGameControllerオブジェクトを取得する
        gameController = GameObject.Find("GameController");
    }

    // 他のColliderがヒット瞬間
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "BlockGreen")
        {
            // 緑ブロックがヒットしたら、ゲームコントローラーに失敗を通知
            gameController.SendMessage("StageFailed");
        }
        // ヒットしたオブジェクトを削除する
        Destroy(other.gameObject);
    }
}
