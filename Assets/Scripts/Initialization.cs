using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム開始(起動)時に一度だけ初期化処理するクラス(エディタ上でも使える)
/// </summary>
public class Initialization : MonoBehaviour {

    //初期化処理が完了したか
    public static bool IsInitialized { get; private set; } = false; 
    public string Ranking;
    public string Rankinghard;

    //=================================================================================
    //起動時
    //=================================================================================
        
    //ゲーム開始時(シーン読み込み前、Awake前)に実行される
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize() {
        new GameObject("StartupInitializer", typeof(Initialization ));
    }
        
    //=================================================================================
    //初期化
    //=================================================================================

    private void Awake() {
        //Debug.Log("初期化通過");
        Ranking = "0,0,0,0,0,0,0,0,0,0";
        PlayerPrefs.SetString("Ranking", Ranking); //順位初期化
        PlayerPrefs.Save();//スコアセーブ
        
        Rankinghard = "0,0,0,0,0,0,0,0,0,0";
        PlayerPrefs.SetString("Rankinghard", Rankinghard); //順位初期化
        PlayerPrefs.Save();//スコアセーブ
            
        //初期化が済んだら自分を消す
        Destroy(gameObject);
        IsInitialized = true;
    }

}
