using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using Akali.Scripts.Managers.StateMachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Bomb : Singleton<Bomb>
{
    private float intensity;
    public PostProcessVolume volume;
    public Material renderer;

    private void Awake()
    {
        LightUp();
        GameStateManager.Instance.GameStatePlaying.OnExecute += UpdateLight;
    }

    public IEnumerator GreenLight()
    {
        volume.weight = intensity;
        //renderer.SetColor("_FirstColor",renderer.GetColor("_SecondColor"));
        renderer.SetFloat("_Bool",1);
        renderer.SetFloat("_Bool2",0);
        yield return new WaitForSeconds(1);
        //renderer.SetColor("_SecondColor",renderer.GetColor("_FirstColor"));
        renderer.SetFloat("_Bool",0);
        renderer.SetFloat("_Bool2",1);
    }

    void LightUp()
    {
        DOTween.To(()=> intensity, x=> intensity = x, 1, 0.5f).SetLoops(-1,LoopType.Yoyo);
    }

    private void UpdateLight()
    {
        volume.weight = intensity;
    }
}
