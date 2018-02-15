using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    public static ulong jewels;
    public static float jewelsPerSecond;
    public static List<GameObject> buildings { get; set; }
    public static List<GameObject> upgrades { get; set; }
    public static float jewelsPerClick;

    
    

	// Use this for initialization
	void Awake() {
        jewels = 0;
        jewelsPerSecond = 0;
	    jewelsPerClick = 1;
        buildings = new List<GameObject>();
        upgrades = new List<GameObject>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
