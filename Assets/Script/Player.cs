using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GManager gameManager;
    //�̗͗p�ϐ�
    public int playerHp;

    // Start is called before the first frame update
    void Start()
    {
        //�������ɑ̗͂�ݒ肷��
        playerHp = 10;
        GameObject managerObject = GameObject.Find("GManager");
        gameManager = managerObject.GetComponent<GManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //�̗͂�0�ɂȂ�����
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
