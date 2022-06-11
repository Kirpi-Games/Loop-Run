using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ResetTrambolin : MonoBehaviour
{
    public JumpSpikeObstacle js;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            js.spikes.DOLocalMove(Vector3.zero, 0.1f);
        }
    }
}
