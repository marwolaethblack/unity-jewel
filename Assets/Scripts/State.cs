﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    public static ulong jewels;
    public static float jewelsPerSecond;
    public static List<GameObject> buildings { get; set; }
    public static List<GameObject> upgrades { get; set; }
    public static float jewelsPerClick;
    public static ulong multiplerBuilding;

    
    

	// Use this for initialization
	void Awake() {
        jewels = 0;
        jewelsPerSecond = 0;
	    jewelsPerClick = 1;
        multiplerBuilding = 1;
        buildings = new List<GameObject>();
        upgrades = new List<GameObject>();

    }

    void Start() {
        InvokeRepeating("IncreaseJewelAmount", 1f, 1f);

    }
	
	// Update is called once per frame
	void Update () {
	}

    void IncreaseJewelAmount()
    {
        jewels = jewels + (ulong)jewelsPerSecond;
    }
}
