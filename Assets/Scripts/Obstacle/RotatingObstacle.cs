using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    public Transform rotateTarget;
    private void Start()
    {
        Rotate();
    }

    public void Rotate()
    {
        rotateTarget.DORotate(new Vector3(0,0,360), 4,RotateMode.LocalAxisAdd).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear);
    }

    public void RotateStop()
    {
        rotateTarget.DOKill();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            RotateStop();
            if (PlayerController.Instance.isFail)
            {
                Rotate();
            }
        }
    }
}
