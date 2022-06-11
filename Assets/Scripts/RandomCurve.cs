using System.Collections;
using System.Collections.Generic;
using Akali.Scripts.Managers.StateMachine;
using AmazingAssets.CurvedWorld;
using DG.Tweening;
using UnityEngine;

public class RandomCurve : MonoBehaviour
{
    public CurvedWorldController controller;
    float horizontal = 10;
    float vertical = 5;
    public void Awake()
    {
        controller = GetComponent<CurvedWorldController>();
        DOTween.To(()=> vertical, x=> vertical = x, -5, 40).SetLoops(-1,LoopType.Yoyo);
        DOTween.To(()=> horizontal, x=> horizontal = x, -10, 40).SetLoops(-1,LoopType.Yoyo);
        GameStateManager.Instance.GameStatePlaying.OnExecute += HorizontalRandomCurve;
        GameStateManager.Instance.GameStatePlaying.OnExecute += VerticalRandomCurve;
    }

    void HorizontalRandomCurve()
    {
        controller.bendHorizontalSize = horizontal;
    }
    
    void VerticalRandomCurve()
    {
        controller.bendVerticalSize = vertical;
    }
    
    
}
