using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�q�I�u�W�F�N�g�̃T�C�Y���i�[���邽�߂̕ϐ�
    private float Left, Right,Top,Bottom;

    //�J�������猩����ʍ����̍��W���i�[����ϐ�
    Vector3 LeftBottom;

    //�J�������猩����ʉE��̍��W���i�[����ϐ�
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

        //�q�I�u�W�F�N�g�̐��������[�v�������s��
        foreach(Transform Child in gameObject.transform)
        {
            //�q�I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if(Child.localPosition.x >= Right)
            {
                //�q�I�u�W�F�N�g�̃��[�J�����W�̉E�[�p�̍��W�ɑ������
                Right = Child.transform.localPosition.x;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԍ��̈ʒu�ɂ����Ȃ�
            if (Child.localPosition.x <= Left)
            {
                //�q�I�u�W�F�N�g�̃��[�J�����W�̍��[�p�̍��W�ɑ������
                Left = Child.transform.localPosition.x;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԏ�̈ʒu�ɂ����Ȃ�
            if (Child.localPosition.z >=Top)
            {
                //�q�I�u�W�F�N�g�̃��[�J�����W�̏�[�p�̍��W�ɑ������
                Top = Child.transform.localPosition.z;
            }
            //�q�I�u�W�F�N�g�̒��ň�ԉ��̈ʒu�ɂ����Ȃ�
            if (Child.localPosition.z <= Bottom)
            {
                //�q�I�u�W�F�N�g�̃��[�J�����W�̉��[�p�̍��W�ɑ������
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
        //���V�t�g���������Ƃ��������x�𑝉�������
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.01f;
        }
        else
        {
            speed = 0.05f;
        }
        //�v���C���[�̃��[���h���W�ɑ��
        transform.position = new Vector3(Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x-Left, RightTop.x - transform.localScale.x-Right),
                                         pos.y,
                                         Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z-Bottom, RightTop.z - transform.localScale.z-Top));
    }
}
