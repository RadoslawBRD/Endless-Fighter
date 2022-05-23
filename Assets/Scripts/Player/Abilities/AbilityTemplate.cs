using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTemplate : ScriptableObject
{

    public new string name;
    public bool isActive = false;
    public float activationTime = 1f;
    public virtual void Activate(GameObject parent)
    {

    }
}
