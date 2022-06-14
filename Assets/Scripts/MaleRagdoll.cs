using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts.Managers;
using DG.Tweening;
using UnityEngine;

public class MaleRagdoll : MonoBehaviour
{
    public GameObject graveStone;
    public SkinnedMeshRenderer renderer;


    private void Start()
    {
        StartCoroutine(ShowGraveStone());
    }

    public IEnumerator ShowGraveStone()
    {
        yield return new WaitForSeconds(2f);
        graveStone.transform.DOScale(1, 0.4f).SetEase(Ease.OutBounce);
        graveStone.transform.DOLocalRotate(new Vector3(-90, 0, -180), 0.1f);
        renderer.enabled = false;
        yield return new WaitForSeconds(7f);
        AkaliPoolManager.Instance.Enqueue<MaleRagdoll>(gameObject);
    }
}
