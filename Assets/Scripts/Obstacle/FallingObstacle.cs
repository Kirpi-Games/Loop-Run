using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    public bool isReset;

    public enum Type
    {
        OpenLeft,OpenRight,OpenBoth
    }

    public Type type;
    
    public Transform doorLeft, doorRight;

    private void OpenLeft()
    {
        doorLeft.DORotate(new Vector3(0, 0, -58), 0.2f,RotateMode.WorldAxisAdd);
    }

    void OpenRight()
    {
        doorRight.DORotate(new Vector3(0,0,-58), 0.2f,RotateMode.WorldAxisAdd);
    }

    void OpenBoth()
    {
        doorLeft.DORotate(new Vector3(0, 0, 90), 0.2f,RotateMode.WorldAxisAdd);
        doorRight.DORotate(new Vector3(0, 0, 90), 0.2f,RotateMode.WorldAxisAdd);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            switch (type)
            {
                case Type.OpenBoth:
                    OpenBoth();
                    break;
                case Type.OpenLeft:
                    OpenLeft();
                    break;
                case Type.OpenRight:
                    OpenRight();
                    break;
            }

            if (isReset)
            {
                return; 
            }
        }
    }
}
