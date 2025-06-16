using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubetrans : MonoBehaviour
{
    private Vector3 targetPosition;
    void Awake()
    {
        //スクリプト無効化
        this.gameObject.GetComponent<cubetrans>().enabled = false; 
    }
    void OnEnable()
    {
        //目標座標の設定
        targetPosition = this.transform.position;
        targetPosition.y = -3.5f;

        //effect宣言＆生成
        GameObject effect = (GameObject)Resources.Load ("cubeeffect");
        Vector3 effectposition = this.transform.position;
        effectposition.y = 0.3f;
        Instantiate (effect, effectposition, Quaternion.identity);
    }
    void Update()
    {
        //座標移動
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, Time.deltaTime);
        //終了処理
        if(this.transform.position.y == targetPosition.y){
            //削除
            Destroy(this.gameObject,3.0f);
            //プログラム終了
            this.gameObject.GetComponent<cubetrans>().enabled = false;
        }
    }
}
