using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Ui_Materials.Scripts.Components;
using DG.Tweening;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int gold;
    
    private void Start()
    {
        transform.parent.DORotate(new Vector3(0, 60, 0), 0.3f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Taptic.Medium();
            MoneyText.Instance.IncreaseMoney(gold);
            transform.parent.DOScale(0, 0.2f).SetEase(Ease.Flash);
        }
    }
}
