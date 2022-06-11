using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using DG.Tweening;
using UnityEngine;

public class JumpSpikeObstacle : Singleton<JumpSpikeObstacle>
{
    public Transform spikes;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            spikes.DOLocalMove(new Vector3(0,10,0), 0.2f).SetEase(Ease.Flash);
        }
    }
}
