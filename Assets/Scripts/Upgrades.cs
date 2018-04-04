﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade { 
    
    public string name { get; set; }
    public uint buildingsRequired { get; set; }

    public string requiredBuilding { get; set; }

    public uint price { get; set; } 

    public float multi { get; set; }

    public Upgrade(string n, uint bR, uint p, float m, string rB)
    {
        this.name = n;
        this.buildingsRequired = bR;
        this.price = p;
        this.multi = m;
        this.requiredBuilding = rB;

    }
}
