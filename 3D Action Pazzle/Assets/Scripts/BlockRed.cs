using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRed : MonoBehaviour
{
    private void OnMouseDown()
    {
        // クリックされるとオブジェクトを削除する
        Destroy(gameObject);
    }
}
