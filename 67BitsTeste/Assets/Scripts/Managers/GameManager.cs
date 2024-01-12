using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("===== Info =====")]
    public GameObject player;
    public int personOnBag;
    public int limitPersonOnBag;
    public int money;
    public int needToUpgrade;

    

    [Header("===== UI =====")]
    public GameObject dropBtn;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drop()
    {
        money += (3 * personOnBag);
        personOnBag = 0;
    }   

    public void Upgrade()
    {
        if(money >= needToUpgrade)
        {
            limitPersonOnBag += 2;
            money -= needToUpgrade;
            needToUpgrade += 2;
            player.GetComponent<PowerUp>().PowerUpPlayer();
            Debug.Log("UP! Limits now: " + limitPersonOnBag.ToString());
        }
        else
        {
            Debug.Log("No Money");
        }
    }
}
