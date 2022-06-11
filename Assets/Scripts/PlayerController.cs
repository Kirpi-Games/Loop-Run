using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using Akali.Scripts;
using Akali.Scripts.Managers.StateMachine;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Transform _checkpoint;
    public bool isFail;
    public bool isPlay;


    private void Awake()
    {
        GameStateManager.Instance.GameStatePlaying.OnExecute += CheckFailPos;
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        _checkpoint = checkpoint.transform;
    }

    void CheckFailPos()
    {
        if (_checkpoint == null)
        {
            isFail = false;
            SwerveController.Instance.swerveSpeed = 0.4f;
            return;
        }
        else
        {
            if (transform.position.z <= _checkpoint.transform.position.z + 2)
            {
                SwerveController.Instance.swerveSpeed = 0.4f;
                isFail = false;
            }    
        }
        
    }

    
    
}
