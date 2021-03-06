﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Building {

    public Building(string n, float bp, float jps, float pi, string sp)
    {
        this.upgrades = new List<Upgrade>();
        this.name = n;
        this.basePrice = bp;
        this.jps = jps;
        this.amount = 0;
        this.priceIncrease = pi;
        this.spritePath = sp;
    }

    public string name { get; set; }

    public uint amount { get; set; }

    public float basePrice { get; set; }

    public float priceIncrease { get; set; }
    public float jps { get; set; }

    public List<Upgrade> upgrades { get; set; }

    public string spritePath { get; set; }
}








