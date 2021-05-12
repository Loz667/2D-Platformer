using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Soldier : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    [SerializeField]
    protected Transform pointA, pointB;
    
   

    // Update is called once per frame
    public abstract void Update();

}
