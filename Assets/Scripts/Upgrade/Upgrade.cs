using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts;
using Akali.Ui_Materials.Scripts.Components;
using TMPro;
using UnityEngine;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;

public class Upgrade : MonoBehaviour
{
    public enum GateType
    {
        Health,Speed,Countdown
    }

    public int goldAmount;
    public string type;
    public string gold;
    public GateType gateType;
    public TextMeshPro tmp;


    private void Awake()
    {
        StartCoroutine(SetTMP(0));
    }

    private IEnumerator SetTMP(float time)
    {
        yield return new WaitForSeconds(time);
        tmp.text = type + goldAmount + gold ;
    }


    void PlayerUpgrade()
    {
        switch (gateType)
        {
            case GateType.Countdown:
                CountUpgrade();
                break;
            case GateType.Health:
                break;
            case GateType.Speed:
                SpeedUpgrade();
                break;
        }
    }
    
    public void SpeedUpgrade()
    {
        if (PlayerPrefs.GetMoney() >= goldAmount)
        {
            SwerveController.Instance.moveSpeed += 0.2f;
            MoneyText.Instance.DecreaseMoney(goldAmount);
        }
        
    }

    public void CountUpgrade()
    {
        if (PlayerPrefs.GetMoney() >= goldAmount)
        {
            Counter.Instance.startTime += 5;
            MoneyText.Instance.DecreaseMoney(goldAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            PlayerUpgrade();
            goldAmount += 150;
            StartCoroutine(SetTMP(3));
        }
    }
}
