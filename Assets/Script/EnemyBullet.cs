using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //球の速度
    public float speed = 2.0f;

    //自然消滅までのタイマー
    public float time = 1.0f;

    //進行方向
    protected Vector3 forward = new Vector3(1, 1, 1);

    //うち出す時の角度
    protected Quaternion forwardAxis = Quaternion.identity;

    //Rigidbody用変数
    protected Rigidbody rb;

    //Enemy用変数
    protected GameObject enemy;

    private GameObject[] enemys;
    //

    // Start is called before the first frame update
    void Start()
    {
        
        //Rigidbody変数を初期化
        rb = this.GetComponent<Rigidbody>(); 
        
        //生成時に進行方向を決める
        if(enemy != null)
        {
            forward = enemy.transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 pos = transform.position;

        transform.position = new Vector3(pos.x, pos.y, pos.z);

        if (pos.z <= -20)
        {
            Destroy(this.gameObject);
        }

        //移動量を進行方向にスピード分だけ加える
        rb.velocity = forwardAxis * forward * speed;

        //空中に浮かないようにする
        rb.velocity = new Vector3(rb.velocity.x,0, rb.velocity.z);

        //時間制限が来たら自然消滅する
        time -= Time.deltaTime;

        if(time <= -5)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //もし当たったオブジェクトがEnemyだったら
        if (other.gameObject.tag == "Player")
        {
            //敵が１体以上残っていたら
            if(enemys.Length >=1)
            {
                other.GetComponent<Player>().Damage();
            }
            
            Destroy(this.gameObject);
        }
    }

    //球を打ち出したキャラクター情報を渡す関数
    public void SetCharacterObject(GameObject Character)
    {
        //球を打ち出したキャラクター情報を受け取る
        this.enemy = Character;
    }
    //打ち出す角度を決める関数
    public void SetForwardAxis(Quaternion Axis)
    {
        //設定された角度を受け取る
        this.forwardAxis = Axis;
    }

}
