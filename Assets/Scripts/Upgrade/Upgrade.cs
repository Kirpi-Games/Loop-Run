using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts;
using Akali.Scripts.Managers;
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
                Taptic.Medium();
                time.SetActive(true);
                speed.SetActive(false);
                break;
            case GateType.Health:
                break;
            case GateType.Speed:
                Taptic.Medium();
                time.SetActive(false);
                speed.SetActive(true);
                break;
        }
    }
    
    public void Particle(bool isRun)
    {
        if (isRun)
        {
            var speed = AkaliPoolManager.Instance.Dequeue<SpeedPower>();
            speed.transform.position = PlayerController.Instance.transform.position + new Vector3(0,2,2);
            speed.transform.SetParent(PlayerController.Instance.transform);    
        }
        else
        {
            var time = AkaliPoolManager.Instance.Dequeue<TimePower>();
            time.transform.position = PlayerController.Instance.transform.position + new Vector3(0,2,2);
            time.transform.SetParent(PlayerController.Instance.transform);
        }
        
    }

    private IEnumerator SetTMP(float time)
    {
        yield return new WaitForSeconds(time);
        tmp.text = goldAmount.ToString();
    }


    void PlayerUpgrade()
    {
        switch (gateType)
        {
            case GateType.Countdown:
                CountUpgrade();
                Particle(false);
                break;
            case GateType.Health:
                break;
            case GateType.Speed:
                SpeedUpgrade();
                Particle(true);
                break;
        }
    }
    
    public void SpeedUpgrade()
    {
        if (PlayerPrefs.GetMoney() >= goldAmount)
        {
            SwerveController.Instance.moveSpeed += 0.2f + goldAmount/1000;
            MoneyText.Instance.DecreaseMoney(goldAmount);
        }
        
    }

    public void CountUpgrade()
    {
        if (PlayerPrefs.GetMoney() >= goldAmount)
        {
            Counter.Instance.startTime += 1 + goldAmount/100;
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
