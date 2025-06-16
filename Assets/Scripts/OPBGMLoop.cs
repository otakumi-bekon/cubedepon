using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OPBGMLoop : MonoBehaviour
{
    private void Awake() 
    {
        string load = SceneManager.GetActiveScene().name;
        if(load == "play")
        {
            //Debug.Log("ロードされています");
            Destroy(this.gameObject); // 自分自身を破棄して終了
        }
        //OPisLoad = true; // ロードされていなかったら、フラグをロード済みに設定する
        Debug.Log(load);
        if(load == "Title")
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
        //Debug.Log ( scene.name + " scene loaded");
    }
}
