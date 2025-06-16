using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int scoreTotall;


    void Start()
    {
        PlayerPrefs.SetInt("scoreTotall", 0);
        PlayerPrefs.Save();
    }

    void Update()
    {
        //スコア初期化用
        if (Input.GetKey(KeyCode.Space)) {
            PlayerPrefs.DeleteAll();
        }
    }
}
