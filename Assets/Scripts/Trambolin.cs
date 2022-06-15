using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts;
using UnityEngine;

public class Trambolin : MonoBehaviour
{
    public float force;
    private float oldSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            if (PlayerController.Instance.isFail)
            {
                return;
            }
            else
            {
                oldSpeed = SwerveController.Instance.moveSpeed;
                SwerveController.Instance.moveSpeed = 10;
                other.GetComponent<Rigidbody>().AddForce(new Vector3(0,force,0),ForceMode.Impulse);
                PlayerController.Instance.animator.SetTrigger("Jump");
                StartCoroutine(SetOldSpeed());
            }
        }
    }

    IEnumerator SetOldSpeed()
    {
        yield return new WaitForSeconds(2);
        SwerveController.Instance.moveSpeed = oldSpeed;
    }
}
