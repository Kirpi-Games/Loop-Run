using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DeathCount : Singleton<DeathCount>
{
    public TextMeshProUGUI text;
    public int deathCount;
    private float startScale;
    private Color32 startColor;
    [SerializeField] private Color32 decreaseColor;

    
    private void OnEnable()
    {
        startColor = text.color;
        startScale = text.transform.localScale.x;
    }
    
    void DisplayCount()
    {
        var currentDeath = deathCount ;
        var newDeath = deathCount + 1;
        text.DOScale(startScale * 1.2f, 0.6f).OnComplete(() => text.DOScale(startScale, 0.2f));
        text.DOColor(decreaseColor, 0.6f).OnComplete(() => text.DOColor(startColor, 0.2f));
        text.DOCounter(currentDeath, newDeath, 0.6f);
        deathCount = newDeath;
    }
    
    public void IncreaseDeath()
    {
        DisplayCount();
    }
}
