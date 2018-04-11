using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelEvent
{
    public JewelEvent(string n, float mp, float cmp, uint dur, float prob, ulong thr)
    {
        this.name = n;
        this.multiplier = mp;
        this.clickMultiplier = cmp;
        this.duration = dur;
        this.probability = prob;
        this.active = false;
        this.threshold = thr;
    }

    public string name { get; set; }
    public float multiplier { get; set; }
    public float clickMultiplier { get; set; }
    public uint duration { get; set; }
    public float probability { get; set; }
    public bool active { get; set; }
    public ulong threshold { get; set; }

}
