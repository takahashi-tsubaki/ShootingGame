using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //���̑��x
    public float speed = 2.0f;

    //���R���ł܂ł̃^�C�}�[
    public float time = 1.0f;

    //�i�s����
    protected Vector3 forward = new Vector3(1, 1, 1);

    //�����o�����̊p�x
    protected Quaternion forwardAxis = Quaternion.identity;

    //Rigidbody�p�ϐ�
    protected Rigidbody rb;

    //Enemy�p�ϐ�
    protected GameObject enemy;

    private GameObject[] enemys;
    //

    // Start is called before the first frame update
    void Start()
    {
        
        //Rigidbody�ϐ���������
        rb = this.GetComponent<Rigidbody>(); 
        
        //�������ɐi�s���������߂�
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

        //�ړ��ʂ�i�s�����ɃX�s�[�h������������
        rb.velocity = forwardAxis * forward * speed;

        //�󒆂ɕ����Ȃ��悤�ɂ���
        rb.velocity = new Vector3(rb.velocity.x,0, rb.velocity.z);

        //���Ԑ����������玩�R���ł���
        time -= Time.deltaTime;

        if(time <= -5)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //�������������I�u�W�F�N�g��Enemy��������
        if (other.gameObject.tag == "Player")
        {
            //�G���P�̈ȏ�c���Ă�����
            if(enemys.Length >=1)
            {
                other.GetComponent<Player>().Damage();
            }
            
            Destroy(this.gameObject);
        }
    }

    //����ł��o�����L�����N�^�[����n���֐�
    public void SetCharacterObject(GameObject Character)
    {
        //����ł��o�����L�����N�^�[�����󂯎��
        this.enemy = Character;
    }
    //�ł��o���p�x�����߂�֐�
    public void SetForwardAxis(Quaternion Axis)
    {
        //�ݒ肳�ꂽ�p�x���󂯎��
        this.forwardAxis = Axis;
    }

}
