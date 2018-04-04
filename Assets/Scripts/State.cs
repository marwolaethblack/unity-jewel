using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class State : MonoBehaviour {

    public static ulong jewels;
    public static float jewelsPerSecond;
    public static List<Building> buildings { get; set; }
    public static List<Upgrade> upgrades { get; set; }
    public static float jewelsPerClick;
    public static ulong multiplerBuilding;


    
    

	// Use this for initialization
	void Awake() {
        jewels = 0;
        jewelsPerSecond = 0;
	    jewelsPerClick = 1;
        multiplerBuilding = 1;

        Upgrade PointerUpdate1 = new Upgrade("Stronger Fingers", 25, 5, 1.2f, "Pointer");

        upgrades = new List<Upgrade>{ PointerUpdate1 };

        Building Pointer = new Building("Pointer", 10, 1, 1.15f);
	    Building JewelGrandma = new Building("JewelGrandmas", 100, 3, 1.15f);
        Building JewelMine = new Building("JewelMine", 500, 10, 1.20f);
	    Building JewelFactory = new Building("JewelFactory", 2000, 80, 1.20f);

        buildings = new List<Building> { Pointer, JewelGrandma, JewelMine, JewelFactory };



    }

    void Start() {
        InvokeRepeating("IncreaseJewelAmount", 1f, 1f);
        SceneManager.LoadScene("Shop");
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
            foreach (Upgrade builtUpgrade in build.upgrades)
            {
                newJps *= builtUpgrade.multi;
            }

            Debug.Log(newJps);
        }

        jewelsPerSecond = newJps;
    }
}
