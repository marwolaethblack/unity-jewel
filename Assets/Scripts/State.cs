using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    public static ulong jewels;
    public static float jewelsPerSecond;
    public static List<Building> buildings { get; set; }
    public static List<GameObject> upgrades { get; set; }
    public static float jewelsPerClick;
    public static ulong multiplerBuilding;


    
    

	// Use this for initialization
	void Awake() {
        jewels = 0;
        jewelsPerSecond = 0;
	    jewelsPerClick = 1;
        multiplerBuilding = 1;

        upgrades = new List<GameObject>();

        Building Pointer = new Building("Pointer", 10, 1, 1.15f);
        Building JewelMine = new Building("JewelMine", 500, 10, 1.20f);

        buildings = new List<Building> { Pointer, JewelMine};



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

    public static void calcNewCps()
    {
        float newJps = 0;

        foreach (var build in buildings)
        {
            newJps += (build.amount * build.jps);
            Debug.Log(newJps);
        }

        jewelsPerSecond = newJps;
    }
}
