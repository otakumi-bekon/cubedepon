using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;
using TMPro;

public class Judgeextra : MonoBehaviour
{
    public List<string[]> _csvData = new List<string[]>();  //CSVファイルの中身を入れるリスト
    public int[] number = new int[9]; // 配列の宣言
    public TextMeshProUGUI totall_score; //合計のスコアを表示するテキスト
    public int scoreTotall; //全体スコア定義
    public int scorecount;
    private float _timeElapsed;  //経過時間
    private float _timeElapsed1;  //経過時間1
    public float _repeatSpan1;

    AudioSource audioSource;
    public AudioClip sucorelo;
    public AudioClip sucoremido;
    public AudioClip sucorehi;

    private int stageNum;
    private int errorNum; // PlayerPrefに保存されていなかった場合の数字


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("トータル:" + PlayerPrefs.GetInt("scoreTotall"));
        _repeatSpan1 = 1;    //実行間隔を1に設定
        _timeElapsed = 0;   //経過時間をリセット
        scoreTotall = PlayerPrefs.GetInt("scoreTotall");
        PlayerPrefs.SetInt("scoreTotall", scoreTotall); //スコア初期化
        PlayerPrefs.Save();//スコアセーブ
        totall_score.text = ((PlayerPrefs.GetInt("scoreTotall")).ToString());
    }

    void Update()
    {
        _timeElapsed += Time.deltaTime;//時間をカウントする

        //経過時間が繰り返す間隔を経過したら
        if (_timeElapsed >= _repeatSpan1)
        {
            //判定処理起動
            judge();
            _timeElapsed = 0;//経過時間をリセットする
        }
    }

    public void judge()
    {
        Fileopen script = gameObject.GetComponent<Fileopen>();
        _csvData = script._csvData;
        create scriptb = gameObject.GetComponent<create>();
        number = scriptb.number;
        //キューブ条件文
        int nowtotall = 0;
        for (int i = 0; i < 9; i++)
        {
            int num = int.Parse(_csvData[i][0]);
            //条件処理
            if ((number[i] == 0 && num == 0) || (number[i] == 1 && num == 1) || (number[i] == 2 && num == 2) || (number[i] == 3 && num == 3) || (number[i] == 4 && num == 4) || (number[i] == 5 && num == 5))
            {
                //色キューブ消去
                number[i] = 99;
                //cube破壊
                GameObject obj = GameObject.Find($"cubenumber{i}(Clone)");
                obj.GetComponent<cubetrans>().enabled = true;
                Destroy(obj, 2.0f);
                scorecount++;
                nowtotall = 100;
            }
        }
        //スコア集計
        if (scorecount != 0)
        {
            audioSource = GetComponent<AudioSource>();
            if (scorecount > 5)
            {
                audioSource.PlayOneShot(sucorehi);
            }
            else if (scorecount > 3)
            {
                audioSource.PlayOneShot(sucoremido);
            }
            else
            {
                audioSource.PlayOneShot(sucorelo);
            }

            scoreTotall = PlayerPrefs.GetInt("scoreTotall");
            stageNum = PlayerPrefs.GetInt("stageNum");
            //基礎ポイント100 * 消した個数 * ステージ数
            double scorecalc = nowtotall * scorecount *stageNum;
            PlayerPrefs.SetInt("scoreTotall", (int)scorecalc + scoreTotall);
            PlayerPrefs.Save();
            totall_score.text = ((PlayerPrefs.GetInt("scoreTotall")).ToString());
            Debug.Log("トータル:" + PlayerPrefs.GetInt("scoreTotall"));
            scorecount = 0;
        }
        _csvData.Clear();
    }
}
