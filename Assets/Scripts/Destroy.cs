using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        //自身の削除
        Destroy(this.gameObject,2.0f);
    }
}
