using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using Akali.Scripts.Managers.StateMachine;
using DG.Tweening;
using UnityEngine;

public class Bomb : Singleton<Bomb>
{
    public Light light;

    private float intensity;


    private void Awake()
    {
        LightUp();
        GameStateManager.Instance.GameStatePlaying.OnExecute += UpdateLight;
        GameStateManager.Instance.GameStateMainMenu.OnEnter += GreenLight;
    }

    public void GreenLight()
    {
        light.intensity = 3;
        light.color = Color.green;
    }

    void LightUp()
    {
        DOTween.To(()=> intensity, x=> intensity = x, 3, 0.5f).SetLoops(-1,LoopType.Yoyo);
    }

    private void UpdateLight()
    {
        light.color = Color.red;
        light.intensity = intensity;
    }
}
