using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwardShot : MonoBehaviour
{
    //�v���C���[
    private GameObject player;
    //���̃Q�[���I�u�W�F�N�g
    public GameObject bullet;
    //�ł��o���Ԋu
    public float time = 1;
    //�ŏ��ɑł��o���܂ł̊Ԋu
    public float delaytime = 1;
    //���݂̃^�C�}�[����
    float nowtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[��������
        nowtime = delaytime;
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̏�񂪓����ĂȂ�������
        if(player == null)
        {
            //�v���C���[���������ď�����������
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //�^�C�}�[�����炷
        nowtime -= Time.deltaTime;
        //�^�C�}�[��0�ȉ��̎�
        if(nowtime <= 0)
        {
            //���𐶐�
            CreateShotObject(-transform.localEulerAngles.y);
           
            //�^�C�}�[��������
            nowtime = time;
        }
       
    }
    private void CreateShotObject(float axis)
    {
        if(player != null)
        {
            //�x�N�g�����擾
            var direction = player.transform.position - transform.position;

            //y�x�N�g����������
            direction.y = 0;

            //�������擾
            var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

            //���𐶐�����
            GameObject bulletclone = Instantiate(bullet, transform.position, Quaternion.identity);

            //EnemyBullet��GetComponent��ϐ��Ƃ��ĕۑ�
            var bulletObject = bulletclone.GetComponent<EnemyBullet>();

            //����ł��o�����I�u�W�F�N�g�̏���n��
            bulletObject.SetCharacterObject(gameObject);

            //����ł��o���p�x�����߂�
            bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));

        }

    }
}
