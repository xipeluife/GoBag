﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Describes the emergency scenario and its properties
/// </summary>
[System.Serializable]
public class Scenario {

    [SerializeField]
    private int _id;

    [SerializeField]
    private string _name;



    /// <summary>
    /// Used to associate different elements with a specific scenario
    /// </summary>
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}
