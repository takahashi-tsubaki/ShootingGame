using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GManager : MonoBehaviour
{
    //�G�̐��𐔂���ϐ�
    private GameObject[] enemy;
    //���@�̐��𐔂���ϐ�
    private GameObject[] player;

    //�p�l����o�^����
    public GameObject GameClearPanel;

    public GameObject GameOverPanel;

    public GameObject ResetBotton;

    public GameObject ClearBottom;

    private int PlayerHp = 10;

    // Start is called before the first frame update

    public void SceneReset()
    {
        string acticeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(acticeSceneName);
    }

    public void ChangeScene(string NextScene)
    {
        SceneManager.LoadScene(NextScene);
    }

    void Start()
    {
        //�p�l�����B��
        GameClearPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        ResetBotton.SetActive(false);
        ClearBottom.SetActive(false);

        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;


    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        //�V�[���̑��݂���Enemy�^�O�������Ă���I�u�W�F�N�g
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //�V�[���ɓG����C�����Ȃ�������
        if(enemy.Length == 0)
        {
            //�p�l����\��������
            GameClearPanel.SetActive(true);
            ClearBottom.SetActive(true);

        }
        if(player.Length == 0)
        {
            GameOverPanel.SetActive(true);
            ResetBotton.SetActive(true);
        }
    }

    public Text textComponent;
    public void Hpcount()
    {
        PlayerHp -= 1;
        Debug.Log("PlayerHp:" + PlayerHp);
        textComponent.text = "PlayerHp : " + PlayerHp;
    }
   
}
