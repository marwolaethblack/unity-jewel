using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Upgrade { 
    
    public string name { get; set; }

    public string requiredBuilding { get; set; }

    public uint price { get; set; } 

    public float multi { get; set; }

    public string description;
    public int requiredBuildingAmount { get; set; }
    public float pointsRequired { get; set; }

    public Upgrade(string n, uint p, float m, string rB, string de, int rBA, float pR)
    {
        this.name = n;
        this.price = p;
        this.multi = m;
        this.requiredBuilding = rB;
        this.description = de;
        this.requiredBuildingAmount = rBA;
        this.pointsRequired = pR;
    }
}
