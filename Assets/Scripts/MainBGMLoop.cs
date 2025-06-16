using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBGMLoop : MonoBehaviour
{
    //public static bool OPisLoad = false;// 自身がすでにロードされているかを判定するフラグ
    //public static bool isLoad = false;
    private void Awake() 
    {
        //opの削除
        GameObject opbgm = GameObject.Find("OPBGM");
        Destroy(opbgm);


        string load = SceneManager.GetActiveScene().name;
        if(load == "Level1_8")// すでにロードされていたら
        { 
            Destroy(this.gameObject); // 自分自身を破棄して終了
            //return;
        }
        //isLoad = true; // ロードされていなかったら、フラグをロード済みに設定する
        //DontDestroyOnLoad(this.gameObject); 
        if(load == "practice")
        {
            Debug.Log("通過");
            DontDestroyOnLoad(this.gameObject); 
        }

        // string load = SceneManager.GetActiveScene().name;
        // Debug.Log(load);
        // if(load != "play")
        // {
        //     SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());

        // }

        // if (OPisLoad)
        // { // すでにロードされていたら
        //     Destroy(this.gameObject); // 自分自身を破棄して終了
        //     return;
        // }
        // isLoad = true; // ロードされていなかったら、フラグをロード済みに設定する
        // DontDestroyOnLoad(this.gameObject); 
    }
}
