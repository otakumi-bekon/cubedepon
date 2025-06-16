using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Fileopen : MonoBehaviour
{
    public string _csvFile;
    public List<string[]> _csvData = new List<string[]>();  // CSVファイルの中身を入れるリスト
    public string[] filePath = new string[] {  // ファイルパスの配列
        "/Users/k22026kk/Desktop/test.txt","/Users/k22065kk/Desktop/test.txt",
        "/Users/k22042kk/Desktop/test.txt","/Users/x22067xx/Desktop/test.txt",
        "/Users/x22080xx/Desktop/test.txt","/Users/x22060xx/Desktop/test.txt"};

    void Awake()
    {
        fopen();
    }
    void Update()
    {
        fopen();
    }

    public void fopen() //ファイルオープン
    {
        //読み込み開始
        //Debug.Log("読み込み開始");

        if (System.IO.File.Exists(filePath[0]))
        {
            // Debug.Log("ここに入ってるよ");
            _csvFile = File.ReadAllText("/Users/k22026kk/Desktop/test.txt"); //test.txtのパスに接続
            StringReader reader = new StringReader(_csvFile); //_csvFileをStringReaderに変換
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();   //１行ずつ読む
                _csvData.Add(line.Split(','));    //読みこんだDataをリストにAddする
            }
        }
        else if (System.IO.File.Exists(filePath[1]))
        {
            // Debug.Log("ここに入ってるよ");
            _csvFile = File.ReadAllText("/Users/k22065kk/Desktop/test.txt"); //test.txtのパスに接続
            StringReader reader = new StringReader(_csvFile); //_csvFileをStringReaderに変換
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();   //１行ずつ読む
                _csvData.Add(line.Split(','));    //読みこんだDataをリストにAddする
            }
        }
        else if (System.IO.File.Exists(filePath[2]))
        {
            // Debug.Log("ここに入ってるよ");
            _csvFile = File.ReadAllText("/Users/k22042kk/Desktop/test.txt"); //test.txtのパスに接続
            StringReader reader = new StringReader(_csvFile); //_csvFileをStringReaderに変換
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();   //１行ずつ読む
                _csvData.Add(line.Split(','));  //読みこんだDataをリストにAddする
            }
        }
        else if (System.IO.File.Exists(filePath[3]))
        {
            // Debug.Log("ここに入ってるよ");
            _csvFile = File.ReadAllText("/Users/x22067xx/Desktop/test.txt"); //test.txtのパスに接続
            StringReader reader = new StringReader(_csvFile); //_csvFileをStringReaderに変換
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();   //１行ずつ読む
                _csvData.Add(line.Split(','));  //読みこんだDataをリストにAddする
            }
        }
        else if (System.IO.File.Exists(filePath[4]))
        {
            // Debug.Log("ここに入ってるよ");
            _csvFile = File.ReadAllText("/Users/x22080xx/Desktop/test.txt"); //test.txtのパスに接続
            StringReader reader = new StringReader(_csvFile); //_csvFileをStringReaderに変換
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();   //１行ずつ読む
                _csvData.Add(line.Split(','));  //読みこんだDataをリストにAddする
            }
        }
        else if (System.IO.File.Exists(filePath[5]))
        {
            // Debug.Log("ここに入ってるよ");
            _csvFile = File.ReadAllText("/Users/x22060xx/Desktop/test.txt"); //test.txtのパスに接続
            StringReader reader = new StringReader(_csvFile); //_csvFileをStringReaderに変換
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();   //１行ずつ読む
                _csvData.Add(line.Split(','));   //読みこんだDataをリストにAddする
            }
        }
        else
        {
            Debug.Log("読み込まれてません");
        }
    }
}
