using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GManager : MonoBehaviour
{
    //敵の数を数える変数
    private GameObject[] enemy;
    //自機の数を数える変数
    private GameObject[] player;

    //パネルを登録する
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
        //パネルを隠す
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
        //シーンの存在するEnemyタグを持っているオブジェクト
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //シーンに敵が一匹もいなかったら
        if(enemy.Length == 0)
        {
            //パネルを表示させる
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
