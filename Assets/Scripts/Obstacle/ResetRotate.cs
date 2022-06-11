using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            transform.parent.GetComponent<RotatingObstacle>().Rotate();
        }
    }
}
