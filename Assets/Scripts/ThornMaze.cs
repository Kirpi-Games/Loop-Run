using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts.Managers.StateMachine;
using DG.Tweening;
using UnityEngine;

public class ThornMaze : MonoBehaviour
{
    public float range;
    [SerializeField] private Transform target;

    private void Awake()
    {
        target = PlayerController.Instance.transform;
        GameStateManager.Instance.GameStatePlaying.OnExecute += CheckPlayer;
    }

    void CheckPlayer()
    {
        if (Vector3.Distance(transform.position,target.position) < range)
        {
            transform.DOMoveY(0.4127787f, 0.2f).SetEase(Ease.Flash);
        }
        else
        {
            transform.DOMoveY(-2, 0.2f).SetEase(Ease.Flash);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
