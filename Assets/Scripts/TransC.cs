using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransC : MonoBehaviour
{
    private Vector3 targetPositionCamera2;
    void Awake()
    {
        //スクリプト無効化
        this.gameObject.GetComponent<TransC>().enabled = false; 
    }
    void OnEnable()
    {
        //Debug.Log("座標変更完了");
        //目標座標の設定
        targetPositionCamera2 = this.transform.position;
        targetPositionCamera2.y = -4.5f;
    }
    void Update()
    {
        //Debug.Log("移動開始");
        //座標移動
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPositionCamera2, Time.deltaTime);
    }
}

