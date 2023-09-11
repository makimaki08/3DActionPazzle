using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BlockGreen : MonoBehaviour
{
    // ブロック破壊エフェクト用オブジェクト
    public GameObject brokenBlocksPrefab;
    // ブロックの硬さ
    public float hardness = 5f;
    // ブロック停止を判断する移動量の閾値
    public float stopDetectMagnitude = 0.1f;
    // ブロック停止を判断する時間
    public float stopDetectTime = 1f;

    // ブロック停止判断中
    private GameObject gameController;
    // ブロック停止フラグ
    private bool isStopCheking = false;
    // ゲームコントローラーオブジェクト
    private float stopTime;
    // Rigidbody
    private Rigidbody _rigidbody;

    void Start()
    {
        // シーンからGameControllerオブジェクトを取得する
        gameController = GameObject.Find("GameController");
        // Rigidbodyコンポーネントを取得する
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ブロックの移動速度が閾値以下かチェック
        if (_rigidbody.velocity.magnitude < stopDetectMagnitude)
        {
            if (!isStopCheking)
            {
                isStopCheking = true;
                // ブロックが停止した時間を記録
                stopTime = Time.time;
            }
        }
        else
        {
            isStopCheking = false;
        }
        // 一定時間停止状態で、Floorの上で停止しているかチェック
        if (isStopCheking
            && (Time.time - stopTime)>stopDetectTime
            && IsGround())
        {
            // GameControllerに成功を伝える
            gameController.SendMessage("StageClear");
        }
    }

    // ブロックがFloorの上に接触しているかどうか
    bool IsGround()
    {
        // Floorが属しているFloorレイヤーのレイヤーマスク
        int layerMaskFloor = 1 << 8;
        // ブロックのした方向にレイを発車してヒットするかチェック
        if (Physics.Raycast(transform.position, Vector3.down,GetComponent<Collider>().bounds.extents.y,layerMaskFloor))
        {
            return true;
        }
        return false;
    }

    // 他のColliderとぶつかった瞬間に呼び出される
    private void OnCollisionEnter(Collision collisionInfo)
    {
        // ぶつかった相手の速度が、硬さを上回るかチェック
        if (collisionInfo.relativeVelocity.magnitude>hardness)
        {
            // ブロック破壊エフェクト用オブジェクトをインスタンス化
            Instantiate(brokenBlocksPrefab, transform.position, brokenBlocksPrefab.transform.rotation);
            // オブジェクトを削除
            Destroy(gameObject);
            // GameControllerに失敗を伝える
            gameController.SendMessage("StageFailed");
        }
    }
}
