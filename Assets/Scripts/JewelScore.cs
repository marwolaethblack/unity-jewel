using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class JewelScore : MonoBehaviour {


    private Text _text; 

    // Use this for initialization
    void Start()
    {
        _text = GameObject.Find("JewelScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
            string text = "Jewels: " + State.jewels + "\nJewels/s: " + State.jewelsPerSecond;
            _text.text = text;
    }
}

