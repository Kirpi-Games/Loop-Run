using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using Akali.Scripts;
using Akali.Scripts.Core;
using Akali.Scripts.Managers;
using Akali.Scripts.Managers.StateMachine;
using DG.Tweening;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Transform _checkpoint;
    public Animator animator;
    public bool isFail;
    public bool isPlay;
    public GameObject male;
    public GameObject female;
    public GameObject ghost;

    private void Awake()
    {
        GameStateManager.Instance.GameStatePlaying.OnExecute += CheckFailPos;
        animator = transform.GetChild(0).transform.GetComponent<Animator>();
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        _checkpoint = checkpoint.transform;
    }

    public void MoveLastCheckpoint()
    {
        if (isFail)
        {
            transform.DOMoveZ(_checkpoint.transform.position.z + 2, 1).SetEase(Ease.InSine);    
        }
    }
    
    
    void CheckFailPos()
    {
        if (_checkpoint == null)
        {
            isFail = false;
            SwerveController.Instance.sensitivity = 10f;
            return;
        }
        else
        {
            if (transform.position.z <= _checkpoint.transform.position.z + 2 && isFail)
            {
                SwerveController.Instance.moveSpeed = 10;
                SwerveController.Instance.sensitivity = 10f;
                isFail = false;
                GameStateManager.Instance.SetGameState(GameStateManager.Instance.GameStateMainMenu);
                PlayerController.Instance.ghost.transform.DOScale(0, 0.1f);
                PlayerController.Instance.male.transform.DOScale(1, 0.1f);
            }    
        }
        
    }

    
    
}
