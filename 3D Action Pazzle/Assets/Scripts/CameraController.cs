using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // クリック開始ポイント
    private Vector2 startPos;

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f; // x座標の移動量
        float moveY = 0f; // y座標の移動量
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            moveX = Input.mousePosition.x - startPos.x;
            moveY = Input.mousePosition.y - startPos.y;
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startPos = Vector2.zero;
        }
        // X軸の回転角度は50度以上または0度以下なら移動量を0に
        if (transform.rotation.eulerAngles.x - moveY >= 50)
        {
            moveY = 0;
        }
        if (transform.rotation.eulerAngles.x - moveY <= 0)
        {
            moveY = 0;
        }
        // y座標移動量でX軸方向に回転
        transform.Rotate(-moveY, 0, 0);
        // x座標の移動量でグローバル空間のY軸方向に回転
        transform.Rotate(0, moveX, 0, Space.World);
    }
}
