using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            PlayerController.Instance.isFail = true;
            SwerveController.Instance.swerveSpeed = 0;
            Taptic.Failure();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 3)
        {
            PlayerController.Instance.isFail = true;
            SwerveController.Instance.swerveSpeed = 0;
            Taptic.Failure();
        }
    }
}
