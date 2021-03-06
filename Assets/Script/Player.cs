using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GManager gameManager;
    //体力用変数
    public int playerHp;

    // Start is called before the first frame update
    void Start()
    {
        //生成時に体力を設定する
        playerHp = 10;
        GameObject managerObject = GameObject.Find("GManager");
        gameManager = managerObject.GetComponent<GManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //体力が0になったら
        if (playerHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        playerHp -= 1;
        gameManager.Hpcount();
        Debug.Log(playerHp);
    }
}
