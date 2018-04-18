using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public class State : MonoBehaviour {

    public static float jewels;
    public static float jewelsPerSecond;
    public static List<Building> buildings { get; set; }
    public static List<Upgrade> upgrades { get; set; }
    public static List<JewelEvent> events { get; set; }

    public static float jewelsPerClick;
    public static float multiplier;
    public static float clickMultiplier;
    private static float lifetimejewels;
    private const string buildingPath = "Sprites/Buildings/";
    private const string upgradePath = "Sprites/Upgrades/";


	// Use this for initialization
	void Awake() {
        StateSaver s = new StateSaver();
        StateSaver.GameData gd = new StateSaver.GameData();
	    gd = s.Load();
	    if (gd != null)
	    {
	        jewels = gd.jewels;
	        jewelsPerSecond = gd.jewelsPerSecond;
	        jewelsPerClick = gd.jewelsPerClick;
	        multiplier = gd.multiplier;
	        clickMultiplier = gd.clickMultiplier;
	        buildings = gd.buildings;
	        upgrades = gd.upgrades;
	        events = gd.events;
	        lifetimejewels = gd.lifetimejewels;
	    }
	    else
	    {
	        jewels = 0;
	        jewelsPerSecond = 0;
	        jewelsPerClick = 1;
	        multiplier = 1;
	        clickMultiplier = 1;

	        Upgrade PointerUpdate1 = new Upgrade("Stronger Fingers", 5, 1.2f, "Pointer", upgradePath + "building");
	        Upgrade JewelGrandmaUpgrade1 = new Upgrade("Cheat Grandmas", 5, 10000f, "JewelGrandma", upgradePath + "upgrade");

	        upgrades = new List<Upgrade> { PointerUpdate1, JewelGrandmaUpgrade1 };

	        Building Pointer = new Building("Pointer", 10, 0.1f, 1.15f, buildingPath + "topaz");
	        Building JewelGrandma = new Building("JewelGrandma", 100, 3, 1.15f, buildingPath + "emerald");
	        Building JewelMine = new Building("JewelMine", 500, 10, 1.20f, buildingPath + "ruby");
	        Building JewelFactory = new Building("JewelFactory", 2000, 80, 1.20f, buildingPath + "PixelatedJewel1.0");

	        buildings = new List<Building> { Pointer, JewelGrandma, JewelMine, JewelFactory };

	        JewelEvent DoubleJewelsEvent = new JewelEvent("Double Jewels", 1, 1, 20, 0.5f, 500);
	        JewelEvent ClickMultiEvent = new JewelEvent("8x jewels\nper tap", 0, 8, 10, 0.3f, 1000);

	        events = new List<JewelEvent> { DoubleJewelsEvent, ClickMultiEvent };
        }
    }

    void Start() {
        InvokeRepeating("IncreaseJewel", 1f, 0.1f);
        SceneManager.LoadScene("Shop");
    }

    void IncreaseJewel()
    {
        jewels += jewelsPerSecond * multiplier;
        lifetimejewels += jewelsPerSecond * multiplier;
    }

    public static void TriggerEvent(JewelEvent e)
    {
        multiplier += e.multiplier;
        clickMultiplier += e.clickMultiplier;
        Thread t = new Thread(() =>
        {
            Thread.Sleep((int)e.duration * 1000);
            multiplier -= e.multiplier;
            clickMultiplier -= e.clickMultiplier;
        });
        t.Start();
    }

    public static void CheckNewEvents()
    {
        foreach (var e in events)
        {
            if (lifetimejewels >= e.threshold)
            {
                e.active = true;
            }
        }
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
        }
        jewelsPerSecond = newJps;
        

        if (newJps / 20 > 1)
        {
            jewelsPerClick = newJps / 20;
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            StateSaver s = new StateSaver();
            StateSaver.GameData gd = new StateSaver.GameData(jewels, jewelsPerSecond, buildings, upgrades, 
                events, jewelsPerClick, multiplier, clickMultiplier, lifetimejewels);
            s.Save(gd);
        }
    }
}
