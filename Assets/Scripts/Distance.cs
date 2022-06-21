using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public float distance;
    public TextMeshProUGUI text;
    private double newDistance;

    private void Update()
    {
        distance = PlayerController.Instance.transform.position.z;
        newDistance = Math.Round(distance,0); 
        text.text = newDistance.ToString() + " M";
    }
}
