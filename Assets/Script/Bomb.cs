using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Bomb : MonoBehaviour
{
    public GameObject particle;

    public int bombCount;

    public GManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    public void Update()
    {
        if(bombCount > 0)
        {
            if (Input.GetKeyUp(KeyCode.B))
            {
               
                GameObject[] enemyBulletobjects = GameObject.FindGameObjectsWithTag("EnemyBullet");
                for (int i = 0; i < enemyBulletobjects.Length; i++)
                {
                    Destroy(enemyBulletobjects[i].gameObject);
                }

                Instantiate(particle, Vector3.zero, Quaternion.identity);

                BombCount();
            }
        }
        

    }
    public Text bombText;
    public void BombCount()
    {
        bombCount--;
        Debug.Log("BombCount:" + bombCount);
        bombText.text = "BonbCount : " + bombCount; ;
    }
}
