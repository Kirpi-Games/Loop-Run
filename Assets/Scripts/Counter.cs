using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using Akali.Scripts;
using Akali.Scripts.Managers;
using Akali.Scripts.Managers.StateMachine;
using DG.Tweening;
using UnityEngine;
using TMPro;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;

public class Counter : Singleton<Counter>
{
    public float startTime;
    public float timeLeft;
    public bool timerOn = false;

    public TextMeshProUGUI textTimer;


    private void Awake()
    {
        GameStateManager.Instance.GameStatePlaying.OnExecute += UpdateTimer;
    }

    void UpdateTimer()
    {
        if (timerOn)
        {
            if (timeLeft >= 0)
            {
                timeLeft -= Time.deltaTime;
                TimeText(timeLeft);
            }
            else
            {
                timeLeft = 0;
                SwerveController.Instance.pressed = false;
                MaleRagdoll(PlayerController.Instance.transform);
                PlayerController.Instance.isFail = true;
                SwerveController.Instance.sensitivity = 0;
                Taptic.Failure();
                PlayerController.Instance.MoveLastCheckpoint();
                timerOn = false;
                DeathCount.Instance.IncreaseDeath();
                ResetTimer();
            }
        }
    }

    void TimeText(float currentTime)
    {
        currentTime += 1;
        float minute = Mathf.FloorToInt(currentTime / 60);
        float second = Mathf.FloorToInt(currentTime % 60);
        textTimer.text = string.Format("{0:00} : {1:00}", minute, second);
    }

    public void ResetTimer()
    {
        timeLeft = startTime;
    }

    public void MaleRagdoll(Transform spawn)
    {
        if (!PlayerController.Instance.isFail)
        {
            PlayerController.Instance.male.transform.DOScale(0, 0.1f);
            PlayerController.Instance.ghost.transform.DOScale(0.1492373f, 0.1f);
            print("Ragdoll");
            var ragdollMale = AkaliPoolManager.Instance.Dequeue<MaleRagdoll>();
            ragdollMale.transform.position = spawn.transform.position + new Vector3(0,0,2);
            var nuke = AkaliPoolManager.Instance.Dequeue<Nuke>();
            nuke.transform.position = spawn.transform.position + new Vector3(0,0,2);
                
        }
    }

}
