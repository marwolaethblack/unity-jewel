using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building {

    public Building(string n, float bp, float jps, float pi)
    {
        this.upgrades = new List<GameObject>();
        this.name = n;
        this.basePrice = bp;
        this.jps = jps;
        this.amount = 0;
        this.priceIncrease = pi;
    }

    public string name { get; set; }

    public uint amount { get; set; }

    public float basePrice { get; set; }

    public float priceIncrease { get; set; }
    public float jps { get; set; }

    public List<GameObject> upgrades { get; set; }

}








