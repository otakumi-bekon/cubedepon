using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransU : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform UIposition;
    private float _timeElapsed;  //経過時間
    private float _timeElapsed1;  //経過時間1
    public float _repeatSpan1;
    void Start()
    {
        _repeatSpan1 = 3;    //実行間隔を1に設定
        _timeElapsed = 0;   //経過時間をリセット
        
        setUI();
        //UIposition =  GetComponent<RectTransform>().position;
        //UIposition.y = -1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;//時間をカウントする

        //経過時間が繰り返す間隔を経過したら
        if (_timeElapsed >= _repeatSpan1)
        {
            //判定処理起動
            if(UIposition.anchoredPosition.y >= 1426)
            {
                Invoke(nameof(setUI), 3);
                _timeElapsed = 0;//経過時間をリセットする

                //UIposition.anchoredPosition = new Vector3(0, -270, 0);
            }else
            {
                UIposition.position += new Vector3(0, 3, 0);//毎フレームy座標を0.1ずつプラス
            }
        }
       
        
    }
    void setUI()
    {
        UIposition.anchoredPosition = new Vector3(0, -360, 0);
        _timeElapsed = 0;//経過時間をリセットする
    }
}
