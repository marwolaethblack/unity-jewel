using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class StateSaver
{
    [Serializable]
    public class GameData
    {
        public GameData(float j, float jps, List<Building> buildings, List<Upgrade> upgrades, List<JewelEvent> e,
            float jpc, float multi, float clickMulti, float lifeTimeJewel)
        {
            this.jewels = j;
            this.jewelsPerSecond = jps;
            this.buildings = buildings;
            this.upgrades = upgrades;
            this.events = e;
            this.jewelsPerClick = jpc;
            this.multiplier = multi;
            this.clickMultiplier = clickMulti;
            this.lifetimejewels = lifeTimeJewel;
        }

        public GameData()
        {
            
        }
        public float jewels;
        public float jewelsPerSecond;
        public List<Building> buildings { get; set; }
        public List<Upgrade> upgrades { get; set; }
        public List<JewelEvent> events { get; set; }

        public float jewelsPerClick;
        public float multiplier;
        public float clickMultiplier;
        public float lifetimejewels;
    }

    public void Save(GameData gd)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Save.dat", FileMode.Create);
        bf.Serialize(file, gd);
        file.Close();
    }

    public GameData Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Save.dat", FileMode.Open);
            GameData newData = (GameData)bf.Deserialize(file);
            file.Close();
            return newData;
        }
        return null;
    }
}
