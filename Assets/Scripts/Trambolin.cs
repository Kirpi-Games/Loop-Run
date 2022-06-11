using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trambolin : MonoBehaviour
{
    public float force;


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
                other.GetComponent<Rigidbody>().AddForce(new Vector3(0,force,0),ForceMode.Impulse);    
            }
            
        }
    }
}
