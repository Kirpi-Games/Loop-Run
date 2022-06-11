using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpike : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            if (transform.parent.GetComponent<Spike>().spikeType == Spike.SpikeType.Trigger)
            {
                transform.parent.GetComponent<Spike>().SetObstacle();
            }
            if (transform.parent.GetComponent<Spike>().spikeType == Spike.SpikeType.MoveLeft)
            {
                transform.parent.GetComponent<Spike>().SetObstacleLeft();
            }
            if (transform.parent.GetComponent<Spike>().spikeType == Spike.SpikeType.MoveRight)
            {
                transform.parent.GetComponent<Spike>().SetObstacleRight();
            }
        }
    }
}
