using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GManager gameManager;
    //‘Ì—Í—p•Ï”
    public int playerHp;

    // Start is called before the first frame update
    void Start()
    {
        //¶¬‚É‘Ì—Í‚ğİ’è‚·‚é
        playerHp = 10;
        GameObject managerObject = GameObject.Find("GManager");
        gameManager = managerObject.GetComponent<GManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //‘Ì—Í‚ª0‚É‚È‚Á‚½‚ç
        if (playerHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        playerHp -= 1;
        gameManager.Hpcount();
        Debug.Log(playerHp);
    }
}
