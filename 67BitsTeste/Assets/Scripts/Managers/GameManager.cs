using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("===== Info =====")]
    public GameObject player;
    public int personOnBack;
    public int limitPersonOnBack;
    public int money;
    public int needToUpgrade;

    

    [Header("===== UI =====")]
    public Text personsOnBackTxt;
    public Text moneyTxt;
    public Text needToUpTxt;
    public GameObject dropBtn;
    public GameObject upBtn;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.FindWithTag("Player");
        upBtn.SetActive(false);
        dropBtn.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UiUpdate();
    }

    public void Drop()
    {
        money += (2 * personOnBack);
        personOnBack = 0;
        player.GetComponent<Stacking>().Drop();
    }   

    public void UpgradePlayer()
    {
        limitPersonOnBack += 2;
        money -= needToUpgrade;
        needToUpgrade += 2;
        player.GetComponent<PowerUp>().PowerUpPlayer();
    }

    public void UiUpdate()
    {
        personsOnBackTxt.text = personOnBack.ToString() + "/" + limitPersonOnBack.ToString();
        moneyTxt.text = money.ToString();
        needToUpTxt.text = needToUpgrade.ToString();

        if(money >= needToUpgrade)
        {
            upBtn.SetActive(true);
        }
        else
        {
            upBtn.SetActive(false);
        }
    }
}
