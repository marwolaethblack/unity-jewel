using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade { 
    
    public string name { get; set; }
    public uint buildingsRequired { get; set; }

    public uint price { get; set; } 

    public Upgrade(string n, uint bR, uint p)
    {
        this.name = n;
        this.buildingsRequired = bR;
        this.price = p;

    }
}
