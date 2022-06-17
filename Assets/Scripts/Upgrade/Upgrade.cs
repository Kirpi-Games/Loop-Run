using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts;
using Akali.Ui_Materials.Scripts.Components;
using GameAnalyticsSDK.Setup;
using TMPro;
using UnityEngine;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;

public class Upgrade : MonoBehaviour
{
    public enum GateType
    {
        Health,Speed,Countdown
    }

    public GameObject speed;
    public GameObject time;
    
    public int goldAmount;
    public string gold;
    public GateType gateType;
    public TextMeshPro tmp;


    private void Awake()
    {
        StartCoroutine(SetTMP(0));
        switch (gateType)
        {
            case GateType.Countdown:
                time.SetActive(true);
                speed.SetActive(false);
                break;
            case GateType.Health:
                break;
            case GateType.Speed:
                time.SetActive(false);
                speed.SetActive(true);
                break;
        }
    }

    private IEnumerator SetTMP(float time)
    {
        yield return new WaitForSeconds(time);
        tmp.text = goldAmount + gold ;
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
            Counter.Instance.startTime += 2;
            MoneyText.Instance.DecreaseMoney(goldAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            PlayerUpgrade();
            goldAmount += 250;
            StartCoroutine(SetTMP(3));
        }
    }
}
