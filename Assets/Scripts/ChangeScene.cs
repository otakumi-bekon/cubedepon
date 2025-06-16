using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    private int Flag; // Unity上にキューブがない状態をFlag = 0とする

    private float step_time; // キューブを認識してから、シーン移動するまでの時間
    
    private float time;  // 1フレーム毎にかかった時間

    private float nokoritime; // 残り時間
    private int stageNum; // 現在のステージ数

    private float span = 1f; // 残り時間の表示を変える時間間隔

    private float loadTime; // 残り時間をロード(取得)する変数

    public TextMeshProUGUI timetext; // 残り時間を表示するテキスト
    public TextMeshProUGUI stagetext; // 現在のステージを表示するテキスト
    public TextMeshProUGUI totall_score; // トータルスコアを表示するテキスト
    public TextMeshProUGUI Timetext2; 

    private GameObject Camera;

    void Awake()
    {
        step_time = 0f; // 初期化

        loadTime = PlayerPrefs.GetFloat("timeLimit"); // 残り時間の取得
        nokoritime = loadTime; // 残り時間の代入

        loadTime = 0f; // 初期化

        timetext.text = (nokoritime.ToString()); // 残り時間をUnityに表示

        stageNum = PlayerPrefs.GetInt("stageNum"); // 現在のステージ数を取得

        stagetext.text = stageNum.ToString(); // 現在のステージ数をUnityに表示

        totall_score.text = ((PlayerPrefs.GetInt("scoreTotall")).ToString()); // 
        
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Escapeキーの入力でresult画面へ遷移
        {
            string load = SceneManager.GetActiveScene().name;
            if(load == "hard"){
                SceneManager.LoadScene("resulthard");
            }else{
                SceneManager.LoadScene("result");
            }
        }

        time += Time.deltaTime; // 1フレーム毎にかかった時間をtimeに代入

        if (time > span) // timeが1秒を超えたら、残り時間が1秒減少
        {
            nokoritime -= span;

            if (nokoritime < 0.5f) // 残り時間が0.5秒未満でresult画面へ遷移開始
            {
                string load = SceneManager.GetActiveScene().name;
                if(load == "hard"){
                    SceneManager.LoadScene("resulthard");
                }else{
                    SceneManager.LoadScene("result");
                }
            }

            PlayerPrefs.SetFloat("timeLimit", nokoritime); // 残り時間を"timeLimit"に保存

            loadTime = load(nokoritime); // "timeLimit"から残り時間を取り出し

            timetext.text = (nokoritime.ToString()); // 残り時間をUnityに表示

            if(nokoritime == 60 || nokoritime == 30){
                Timetext2.text = nokoritime.ToString();
                Timetext2.color = Color.white;
                Timetext2.alpha = 0.2f;
                Camera.GetComponent<Shakeshake>().doit();
            }else if(nokoritime == 10){
                Timetext2.text = nokoritime.ToString();
                Timetext2.color = Color.yellow;
                Timetext2.alpha = 0.2f;
                Camera.GetComponent<Shakeshake>().doit();
            }else if(nokoritime <= 5){
                Timetext2.text = nokoritime.ToString();
                Timetext2.color = Color.red;
                Timetext2.alpha = 0.2f;
                Camera.GetComponent<Shakeshake>().doit();
            }else{
                Timetext2.text = "";
            }

            time = 0f; // timeを初期化
        }

        Flag = 0; // Unity上にキューブがない状態をFlag = 0とする

        for (int i = 0; i < 9; i++)
        {
            if (GameObject.Find($"cubenumber{i}(Clone)"))
            {
                Flag = 1; // Unity上にキューブがあるとき、Flag = 1とする
            }
        }

        if (Flag == 0) // Unity上にキューブがないとき
        {
            
            Camera.GetComponent<TransC>().enabled = true;


            PlayerPrefs.SetFloat("timeLimit", loadTime); // "timeLimit"に残り時間を代入

            step_time += Time.deltaTime; // キューブを認識してからの時間をカウント

            if (step_time >= 2.0f) // キューブを認識してから2秒経ったとき
            {
                
                stageNum++;
                PlayerPrefs.SetInt("stageNum", stageNum);
                PlayerPrefs.Save();
                string load = SceneManager.GetActiveScene().name;
                if (load == "hard") // ステージ数が9で"extra"へシーン遷移
                {
                    SceneManager.LoadScene("hard");
                }
                else // ステージ数が８以下で"Level1_8"へシーン遷移
                {
                    Scenenext();
                }

            }
        }
    }

    void Scenenext() // "Level1_8"へシーン遷移
    {
        SceneManager.LoadScene("Level1_8");
    }

    // void Sceneextra() // "extra"へシーン遷移
    // {
    //     SceneManager.LoadScene("extra");
    // }

    float load(float nokoritime) // "timeLimit"から残り時間を取得
    {
        loadTime = PlayerPrefs.GetFloat("timeLimit", nokoritime);
        return loadTime;
    }
}
