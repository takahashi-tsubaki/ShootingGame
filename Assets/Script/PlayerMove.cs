using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //子オブジェクトのサイズを格納するための変数
    private float Left, Right,Top,Bottom;

    //カメラから見た画面左下の座標を格納する変数
    Vector3 LeftBottom;

    //カメラから見た画面右上の座標を格納する変数
    Vector3 RightTop;

    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        //
        var distance = Vector3.Distance(Camera.main.transform.position, transform.forward);

        //
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));

        //
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        //子オブジェクトの数だけループ処理を行う
        foreach(Transform Child in gameObject.transform)
        {
            //子オブジェクトの中で一番右の位置にいたなら
            if(Child.localPosition.x >= Right)
            {
                //子オブジェクトのローカル座標の右端用の座標に代入する
                Right = Child.transform.localPosition.x;
            }
            //子オブジェクトの中で一番左の位置にいたなら
            if (Child.localPosition.x <= Left)
            {
                //子オブジェクトのローカル座標の左端用の座標に代入する
                Left = Child.transform.localPosition.x;
            }
            //子オブジェクトの中で一番上の位置にいたなら
            if (Child.localPosition.z >=Top)
            {
                //子オブジェクトのローカル座標の上端用の座標に代入する
                Top = Child.transform.localPosition.z;
            }
            //子オブジェクトの中で一番下の位置にいたなら
            if (Child.localPosition.z <= Bottom)
            {
                //子オブジェクトのローカル座標の下端用の座標に代入する
                Bottom = Child.transform.localPosition.z;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            pos.z += speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.z -= speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed;
        }
        //左シフトを押したときだけ速度を増加させる
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.01f;
        }
        else
        {
            speed = 0.05f;
        }
        //プレイヤーのワールド座標に代入
        transform.position = new Vector3(Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x-Left, RightTop.x - transform.localScale.x-Right),
                                         pos.y,
                                         Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z-Bottom, RightTop.z - transform.localScale.z-Top));
    }
}
