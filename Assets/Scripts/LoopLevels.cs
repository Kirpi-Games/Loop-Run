using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts.Core;
using Akali.Scripts.Managers;
using Akali.Scripts.Managers.StateMachine;
using UnityEngine;
using Akali.Scripts.Utilities;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;

public class LoopLevels : MonoBehaviour
{
    public List<GameObject> loop = new List<GameObject>();
    public float zSpawn;
    public float tileLenght;


    private void Start()
    {
        CreateTiles();
        
    }

    private float transformX;
    
    void Update()
    {
        float xClamp = 0;
        transformX = Mathf.Clamp(transformX, -xClamp, xClamp);
        transform.position = new Vector3(transformX, 0, PlayerController.Instance.transform.position.z - 1);
    }


    private void CreateTiles()
    {
        print(PlayerPrefs.GetLevel());
        if (PlayerPrefs.GetLevel() < loop.Count)
        {
            for (int i = PlayerPrefs.GetLevel(); i < loop.Count; i++)
            {
                print("Loop Platform Olustu");
                Instantiate(loop[i], transform.forward * zSpawn, transform.rotation);
                zSpawn += tileLenght;
            }    
        }
        if (PlayerPrefs.GetLevel() <= loop.Count)
        {
            for (int j = 0; j < PlayerPrefs.GetLevel(); j++)
            {
                Instantiate(loop[j], transform.forward * zSpawn, transform.rotation);
                zSpawn += tileLenght;
            }    
        }
        
    }
    
}
