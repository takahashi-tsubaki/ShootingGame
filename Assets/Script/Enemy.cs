using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�̗͗p�ϐ�
    public int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        //�������ɑ̗͂�ݒ肷��
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //�̗͂�0�ɂȂ�����
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
