using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class JewelScore : MonoBehaviour {


    private Text _text;
    private Text _text1;

    // Use this for initialization
    void Start()
    {
        _text = GameObject.Find("JewelScoreText").GetComponent<Text>();
        _text1 = GameObject.Find("BuildingPrice1Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
            string text = "Jewels: " + State.jewels + "\nJewels/s: " + State.jewelsPerSecond;
            _text.text = text;

            string text1 = "Price: " + State.buildings.Find( x=>x.name == "Pointer").basePrice;
            _text1.text = text1;

    }
    }

