using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Giyotin : MonoBehaviour
{
    public Transform targetObstacle;
    public Transform otherObstacle;

    void ReleaseBlade()
    {
        targetObstacle.DOMoveY(0, 1.1f).SetEase(Ease.InExpo);
    }
    
    public void SetBlade()
    {
        targetObstacle.DOMoveY(5, 1.2f).SetEase(Ease.Linear);
        otherObstacle.DOMoveY(5, 1.2f).SetEase(Ease.Linear);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            if (!PlayerController.Instance.isFail)
            {
                ReleaseBlade();
            }
            else
            {
                SetBlade();
            }
        }
    }
}
