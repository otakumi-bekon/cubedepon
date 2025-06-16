using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // ここを加える
//using System.Collections.Generic;
using System.Linq;


public class Log : MonoBehaviour
{
    public int scoreTotall;
    public string Ranking;
    public string Rankinghard;
    public TextMeshProUGUI yourscore;
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI Text3;
    public TextMeshProUGUI Text4;
    public TextMeshProUGUI Text5;
    public TextMeshProUGUI Text6;
    public TextMeshProUGUI Text7;
    public TextMeshProUGUI Text8;
    public TextMeshProUGUI Text9;
    public TextMeshProUGUI Text10;

    private float span = 9;
    private float time;

    //private int yourscoretext = 0;
    private int[] scorerank = new int[4];//ランク格納用
    public List<string[]> _csvData = new List<string[]>();  //CSVファイルの中身を入れるリスト
    public List<int> hoge = new List<int>();
    
    private int yourRank = 1;
    private string mozi = ": ";
    void Awake()
    {
        GameObject mainbgm = GameObject.Find("Main BGM");
        Destroy(mainbgm);
    }
    void Start()
    {   
        string load = SceneManager.GetActiveScene().name;
        if(load == "result")
        {
            Ranking = PlayerPrefs.GetString("Ranking");
            scoreTotall = PlayerPrefs.GetInt("scoreTotall");
            PlayerPrefs.SetString("Ranking", Ranking); //順位初期化
            PlayerPrefs.Save();//スコアセーブ
            string[] RankList = Ranking.Split(',');
            for(int i = 0;i<RankList.Length;i++){
                //Debug.Log(RankList[i]);
                hoge.Add(int.Parse(RankList[i]));
            }
            hoge.Add(scoreTotall);
            hoge.Sort();
            hoge.Reverse();
            var result = hoge.Take(10).ToList();
            for(int i=0;i<6;i++){
                int num = i+1;
                switch (i)
                {
                    case 0:
                        Text1.text = result[0].ToString().PadLeft(8);
                        break;
                    case 1:
                        Text2.text = result[1].ToString().PadLeft(8);
                        break;
                    case 2:
                        Text3.text = result[2].ToString().PadLeft(8);
                        break;
                    case 3:
                        Text4.text = result[3].ToString().PadLeft(8);
                        break;      
                    default:
                        break;
                }
            }
            int count = 1;
            int ifSameScore = 0; // 同じスコアが複数ある場合、上位の順位を表示するための変数
            foreach (int item in hoge)
            {
                if (item == scoreTotall && ifSameScore == 0)
                {
                yourRank = count;
                ifSameScore = 1;
                }
                //Debug.Log(count + ":" + item);
                count++;
            }
            yourscore.text = scoreTotall.ToString().PadLeft(8);
            Ranking += "," + scoreTotall.ToString();
            PlayerPrefs.SetString("Ranking", Ranking); //順位初期化
            PlayerPrefs.Save();//スコアセーブ
            Debug.Log(Ranking);
        }else
        {
            //hardモードのランキング処理
            Rankinghard = PlayerPrefs.GetString("Rankinghard");//
            scoreTotall = PlayerPrefs.GetInt("scoreTotall");//
            PlayerPrefs.SetString("Rankinghard", Rankinghard); //順位初期化
            PlayerPrefs.Save();//スコアセーブ
            string[] RankListhard = Rankinghard.Split(',');
            for(int i = 0;i<RankListhard.Length;i++){
                //Debug.Log(RankList[i]);
                hoge.Add(int.Parse(RankListhard[i]));
            }
            hoge.Add(scoreTotall);
            hoge.Sort();
            hoge.Reverse();
            var resulthard = hoge.Take(10).ToList();
            for(int i=0;i<6;i++){
                int num = i+1;
                switch (i)
                {
                    case 0:
                        Text1.text = resulthard[0].ToString().PadLeft(8);
                        break;
                    case 1:
                        Text2.text = resulthard[1].ToString().PadLeft(8);
                        break;
                    case 2:
                        Text3.text = resulthard[2].ToString().PadLeft(8);
                        break;
                    case 3:
                        Text4.text = resulthard[3].ToString().PadLeft(8);
                        break;      
                    default:
                        break;
                }
            } 
            int count = 1;
            int ifSameScore = 0; // 同じスコアが複数ある場合、上位の順位を表示するための変数
            foreach (int item in hoge)
            {
                if (item == scoreTotall && ifSameScore == 0)
                {
                yourRank = count;
                ifSameScore = 1;
                }
                //Debug.Log(count + ":" + item);
                count++;
            }
            yourscore.text = scoreTotall.ToString().PadLeft(8);
            Rankinghard += "," + scoreTotall.ToString();
            PlayerPrefs.SetString("Rankinghard", Rankinghard); //順位初期化
            PlayerPrefs.Save();//スコアセーブ
            Debug.Log(Rankinghard);
        }
    }

    void Update()
    {
        Fileopen script = gameObject.GetComponent<Fileopen>(); // Fileopenをインスタンス化
        _csvData = script._csvData; // Fileopenから_csvDataを取得
        //return,赤色でタイトルへ
        time += Time.deltaTime; // 1フレーム毎にかかった時間をtimeに代入

        if (Input.GetKeyDown(KeyCode.Return) || time > span)
        {
            SceneManager.LoadScene("Title");
        }
        _csvData.Clear();
    }
}
