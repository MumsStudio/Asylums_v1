﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newInfo")]
public class Info : ScriptableObject
{
    public int infoId;
    public string infoTitle;
    public string description;
}
