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
        }
    }
}
