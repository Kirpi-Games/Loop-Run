using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts;
using Akali.Scripts.Managers;
using DG.Tweening;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            MaleRagdoll(other.transform);
            PlayerController.Instance.isFail = true;
            SwerveController.Instance.sensitivity = 0;
            Taptic.Failure();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 3)
        {
            MaleRagdoll(other.transform);
            PlayerController.Instance.isFail = true;
            SwerveController.Instance.sensitivity = 0;
            Taptic.Failure();
        }
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
            ragdollMale.transform.SetParent(transform.transform.root);    
        }
    }
}
