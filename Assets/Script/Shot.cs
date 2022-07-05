using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //ゲームオブジェクトからインスペクターを参照するための変数
    public GameObject bullet;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //球を生成する
            Instantiate(bullet,transform.position,Quaternion.identity);
        }
    }
}
