using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    private Vector3 targetPositionCamera;
    // Start is called before the first frame update
    void Start()
    {
        targetPositionCamera = this.transform.position;
        targetPositionCamera.y = 3.87f;
    }
    // Update is called once per frame
    void Update()
    {
        //座標移動
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPositionCamera, Time.deltaTime);
        if(this.transform.position.y == targetPositionCamera.y){
            //プログラム終了
            this.gameObject.GetComponent<Camera1>().enabled = false;
        }
    }
}
