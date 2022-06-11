using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public enum SpikeType
    {
        Trigger,NonTrigger,MoveLeft,MoveRight
    }

    public SpikeType spikeType;

    public Transform obstacle;

    void ObstacleTrigger()
    {
        obstacle.DOLocalMoveY(1.5f, 0.3f);
    }

    public void SetObstacle()
    {
        obstacle.DOLocalMoveY(-3.5f, 0.3f);
    }
    
    public void SetObstacleLeft()
    {
        obstacle.DOLocalMoveY(-3.5f, 0.3f);
        transform.parent.DOMoveX(2,0.4f).SetEase(Ease.Linear);
    }
    public void SetObstacleRight()
    {
        obstacle.DOLocalMoveY(-3.5f, 0.3f);
        transform.parent.DOMoveX(-2,0.4f).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            switch (spikeType)
            {
                case SpikeType.Trigger :
                    ObstacleTrigger();
                    break;
                case SpikeType.MoveLeft :
                    transform.parent.DOMoveX(-2,0.4f).SetEase(Ease.Linear);
                    ObstacleTrigger();
                    break;
                case SpikeType.MoveRight :
                    transform.parent.DOMoveX(2,0.4f).SetEase(Ease.Linear);
                    ObstacleTrigger();
                    break;
                case SpikeType.NonTrigger :
                    return;
                    break;
            }

            if (PlayerController.Instance.isFail)
            {
                switch (spikeType)
                {
                    case SpikeType.Trigger :
                        SetObstacle();
                        break;
                    case SpikeType.MoveLeft :
                        SetObstacleLeft();
                        break;
                    case SpikeType.MoveRight :
                        SetObstacleRight();
                        break;
                    case SpikeType.NonTrigger :
                        return;
                        break;
                }
            }
        }
    }
}
