using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //体力用変数
    public int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        //生成時に体力を設定する
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //体力が0になったら
        if(enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Damage()
    {
        enemyHp -= 1;
        Debug.Log(enemyHp);
    }
   
}
