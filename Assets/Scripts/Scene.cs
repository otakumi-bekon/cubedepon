using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene : MonoBehaviour
{

    private int stageNum; // 現在のステージ数
    public float timeLimit; // 残り時間
    private float loadTime; // 残り時間をロード(取得)する変数
    public string Ranking;

    void Start()
    {
        stageNum = 1; // 初期化
        PlayerPrefs.SetInt("stageNum", stageNum); // "stageNum"を初期化
        PlayerPrefs.Save();
        
        
    }

    void Update()
    {

        Fileopen script = gameObject.GetComponent<Fileopen>(); // Fileopenをインスタンス化
        var _csvData = script._csvData; // Fileopenから_csvDataを取得

        string load = SceneManager.GetActiveScene().name;

        if(load == "Title")
        {
            //Invoke("loop", 30.0f); // 30秒後にloop関数を呼び出す
            if (_csvData[4][0] == "1" || Input.GetKey(KeyCode.Return))
            {
                // loadTime = 100f;  // 制限時間の設定
                // PlayerPrefs.SetFloat("timeLimit", loadTime); // 制限時間の初期化
                // PlayerPrefs.Save();
                SceneManager.LoadScene("play"); 
            }
        }else if(load == "play")
        {
            if (_csvData[4][0] == "2" || Input.GetKey(KeyCode.Return))
            {
                loadTime = 100f;  // 制限時間の設定
                PlayerPrefs.SetFloat("timeLimit", loadTime); // 制限時間の初期化
                PlayerPrefs.Save();
                SceneManager.LoadScene("practice"); 
            }
            if (_csvData[4][0] == "0")
            {
                loadTime = 100f;  // 制限時間の設定
                PlayerPrefs.SetFloat("timeLimit", loadTime); // 制限時間の初期化
                PlayerPrefs.Save();
                SceneManager.LoadScene("hard"); 
            }
        }

        
        _csvData.Clear(); // キャッシュの削除

    }
}
