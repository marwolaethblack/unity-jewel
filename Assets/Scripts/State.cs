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
    public static float lifetimejewels;
    private const string buildingPath = "Sprites/Buildings/";


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

            //Building Upgrades
            Upgrade BasicPointerUpgrade = new Upgrade("Ambidextrous", 500, 1.5f, "Pointer", "Makes Pointers 50% better", 0, 0);
	        Upgrade PointerUpgrade1 = new Upgrade("Stronger Fingers", 5000, 2f, "Pointer", "Makes Pointers 100% better", 25 ,0);
            Upgrade PointerUpgrade2 = new Upgrade("Iron Fingers", 15000, 2f, "Pointer", "Makes Pointers 100% better", 50, 0);
	        Upgrade PointerUpgrade3 = new Upgrade("Tap God", 200000, 2f, "Pointer", "Makes Pointers 100% better", 75, 0);

            Upgrade GrandmaUpgrade1 = new Upgrade("Better Pensions", 5000, 2f, "JewelGrandma", "Makes Grandmas 100% better", 25, 0);
	        Upgrade GrandmaUpgrade2 = new Upgrade("Better Health-Care", 25000, 2f, "JewelGrandma", "Makes Grandmas 100% better", 50, 0);
	        Upgrade GrandmaUpgrade3 = new Upgrade("Golden Inhaler", 250000, 2f, "JewelGrandma", "Makes Grandmas 100% better", 75, 0);

	        Upgrade FarmUpgrade1 = new Upgrade("Stronger Hoes", 10000, 2f, "JewelFarm", "Makes Farms 100% better", 25, 0);
	        Upgrade FarmUpgrade2 = new Upgrade("Better plows", 75000, 2f, "JewelFarm", "Makes Farms 100% better", 50, 0);
	        Upgrade FarmUpgrade3 = new Upgrade("Bejeweled™ Tractor", 750000, 2f, "JewelFarm", "Makes Farms 100% better", 75, 0);

	        Upgrade JewelMineUpgrade1 = new Upgrade("Stone Pickaxe", 50000, 2f, "JewelMine", "Makes Mines 100% better", 25, 0);
	        Upgrade JewelMineUpgrade2 = new Upgrade("Iron Pickaxe", 200000, 2f, "JewelMine", "Makes Mines 100% better", 50, 0);
	        Upgrade JewelMineUpgrade3 = new Upgrade("Diamond Pickaxe", 2000000, 2f, "JewelMine", "Makes Mines 100% better", 75, 0);

            Upgrade BankUpgrade1 = new Upgrade("Student Loans", 250000, 2f, "JewelBank", "Makes Banks 100% better", 25, 0);
            Upgrade BankUpgrade2 = new Upgrade("Bitcoin Investment", 850000, 2f, "JewelBank", "Makes Banks 100% better", 50, 0);
            Upgrade BankUpgrade3 = new Upgrade("BITCONNEEEEECT", 1500000, 2f, "JewelBank", "Makes Banks 100% better", 75, 0);

            Upgrade JewelCometUpgrade1 = new Upgrade("Starstruck", 1000000, 2f, "JewelComet", "Makes Comets 100% better", 25, 0);
            Upgrade JewelCometUpgrade2 = new Upgrade("Shooting Stars", 2500000, 2f, "JewelComet", "Makes Comets 100% better", 50, 0);
            Upgrade JewelCometUpgrade3 = new Upgrade("All Star", 5000000, 2f, "JewelComet", "Makes Comets 100% better", 75, 0);

            //General Upgrades
            Upgrade BasicGrandmaUpgrade = new Upgrade("Grandma support", 3000, 1.5f, "JewelGrandma", "Makes Grandmas 50% better",0,0);
            Upgrade BasicFarmUpgrade = new Upgrade("Jewel Fertilizer", 6000, 1.5f, "JewelFarm", "Makes Farms 50% better", 0, 0);
            Upgrade ExtremePointerUpgrade = new Upgrade("Thousand fingers", 1000000, 10f, "Pointer", "Makes Pointers 1000% better",0,0);

            upgrades = new List<Upgrade> { BasicPointerUpgrade, BasicGrandmaUpgrade, BasicFarmUpgrade,
                PointerUpgrade1, PointerUpgrade2, PointerUpgrade3,
                GrandmaUpgrade1, GrandmaUpgrade2, GrandmaUpgrade3,
                FarmUpgrade1, FarmUpgrade2, FarmUpgrade3,
                JewelMineUpgrade1, JewelMineUpgrade2, JewelMineUpgrade3,
                BankUpgrade1, BankUpgrade2, BankUpgrade3,
                JewelCometUpgrade1, JewelCometUpgrade2, JewelCometUpgrade3,
                ExtremePointerUpgrade,
            };

	        Building Pointer = new Building("Pointer", 10, 0.1f, 1.1f, buildingPath + "pointer");
	        Building JewelGrandma = new Building("JewelGrandma", 100, 0.5f, 1.1f, buildingPath + "grandma");
            Building JewelFarm = new Building("JewelFarm", 500, 2.5f, 1.1f, buildingPath + "jewelfarm");
	        Building JewelMine = new Building("JewelMine", 3000, 8, 1.1f, buildingPath + "jewelmine");
	        Building JewelFactory = new Building("JewelFactory", 15000, 40, 1.1f, buildingPath + "jewelfactory");
            Building JewelBank = new Building("JewelBank", 50000, 200, 1.1f, buildingPath + "bank");
            Building JewelComet = new Building("JewelComet", 600000, 1000, 1.1f, buildingPath + "comet");


	        buildings = new List<Building> { Pointer, JewelGrandma, JewelFarm,  JewelMine, JewelFactory, JewelBank, JewelComet };

	        JewelEvent DoubleJewelsEvent = new JewelEvent("Double Jewels", 1, 1, 20, 20f, 500);
	        JewelEvent ClickMultiEvent = new JewelEvent("8x jewels\nper tap", 0, 8, 20, 20f, 1000);
            JewelEvent TripleJewelsEvent = new JewelEvent("Triple Jevels!", 2, 1, 20, 10f, 50000);

	        events = new List<JewelEvent> { DoubleJewelsEvent, ClickMultiEvent, TripleJewelsEvent };
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
        

        if (newJps / 10 > 1)
        {
            jewelsPerClick = newJps / 10;
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
