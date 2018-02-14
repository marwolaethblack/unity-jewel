using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    public static ulong jewels { get; set; }
    public static float jewelsPerSecond { get; set; }
    public static List<GameObject> buildings { get; set; }
    public static List<GameObject> upgrades { get; set; }

    
    

	// Use this for initialization
	void Awake () {
        jewels = 0;
        jewelsPerSecond = 0;
        buildings = new List<GameObject>();
        upgrades = new List<GameObject>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
