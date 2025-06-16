using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FadeIn : MonoBehaviour
{
    public TextMeshProUGUI practice;
    private int stageNum; // 現在のステージ数
    private int Flag;
    // Start is called before the first frame update
    void Start()
    {
        stageNum = PlayerPrefs.GetInt("stageNum"); // 現在のステージ数を取得
        if(stageNum == 1)
        {
            practice.text = "-practice-";
        }else{
            practice.text = "-stage " + stageNum.ToString() + "-";
        }
        
        practice.alpha = 0;
        Flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Flag == 0)
        {
            practice.alpha += 0.01f;
            if(practice.alpha >= 1)
            {
                Flag = 1;
            }
        }else
        {
            practice.alpha -= 0.01f;
        }
    }
}