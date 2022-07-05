using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;
    //球のゲームオブジェクト
    public GameObject bullet;
    //
    public int bulletWayNum = 3;
    //
    public float bulletWaySpace = 30;
    //
    public float bulletRad = 0;

    //打ち出す間隔
    public float time = 1;
    //最初に打ち出すまでの間隔
    public float delaytime = 1;
    //現在のタイマー時間
    float nowtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        //タイマーを初期化
        nowtime = delaytime;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの情報が入ってなかったら
        if (player == null)
        {
            //プレイヤーをさがして情報を所得する
            player = GameObject.FindGameObjectWithTag("Player");
        }
       
        //タイマーを減らす
        nowtime -= Time.deltaTime;
        //タイマーが0以下の時
        if (nowtime <= 0)
        {
            //角度調整用の変数
            float bulletWaySpaceSplit = 0;

            for(int i = 0;i<bulletWayNum;i++)
            {
                //球を生成
                CreateShotObject(bulletWaySpace - bulletWaySpaceSplit + transform.localEulerAngles.y);

                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }
           
            //タイマーを初期化
            nowtime = time;
        }
    }

    private void CreateShotObject(float axis)
    {

        if(player!=null)
        {
            //ベクトルを取得
            var direction = player.transform.position - transform.position;

            //yベクトルを初期化
            direction.y = 0;

            //向きを取得
            var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

            //球を生成する
            GameObject bulletclone = Instantiate(bullet, transform.position, Quaternion.identity);

            //EnemyBulletのGetComponentを変数として保存
            var bulletObject = bulletclone.GetComponent<EnemyBullet>();

            //球を打ち出したオブジェクトの情報を渡す
            bulletObject.SetCharacterObject(gameObject);

            //球を打ち出す角度を決める
            bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));

        }

    }
}
