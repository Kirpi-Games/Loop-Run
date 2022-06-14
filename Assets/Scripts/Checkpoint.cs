using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts.Managers;
using Akali.Scripts.Managers.StateMachine;
using Akali.Ui_Materials.Scripts.Components;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform flag1, flag2;
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerController.Instance.isPlay)
        {
            if (other.gameObject.layer == 3)
            {
                if (!PlayerController.Instance.isFail)
                {
                    MoneyText.Instance.IncreaseMoney(100);
                    print("Collided");
                    PlayerController.Instance.SetCheckpoint(transform);
                    AkaliLevelManager.Instance.LevelIsCompleted();
                    ParticleFlag(flag1);
                    ParticleFlag(flag2);
                }
                else
                {
                    PlayerController.Instance.isFail = false;
                }
            }
        }
    }

    public void ParticleFlag(Transform spawn)
    {
        var confetti = AkaliPoolManager.Instance.Dequeue<Confetti>();
        confetti.transform.position = spawn.transform.position + new Vector3(0,2,0);
        confetti.transform.SetParent(spawn.transform);
    }
}
